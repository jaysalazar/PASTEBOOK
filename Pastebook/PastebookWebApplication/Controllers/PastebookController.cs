using PastebookBusinessLogic.BusinessLogic;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class PastebookController : Controller
    {
        PasteBookManager manager = new PasteBookManager();
        PasswordManager passwordManager = new PasswordManager();

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Countries = manager.RetrieveAllCountries();
            return View();
        }

        [HttpPost]
        public ActionResult Details(UserModel model)
        {
            ViewBag.Countries = manager.RetrieveAllCountries();

            if (manager.CheckEmailAddress(model.EmailAddress) == true)
            {
                ModelState.AddModelError("EmailAddress", "Email Address is already taken.");
                return View("Register");
            }

            if (manager.CheckUsername(model.Username) == true)
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return View("Register");
            }

            if (ModelState.IsValid)
            {
                manager.CreateUser(model);
                return RedirectToAction("LogIn");
            }

            return View("Register");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string emailAddress, string passwordHash)
        {
            if (manager.CheckEmailAddress(emailAddress))
            {
                UserModel userModel = new UserModel();

                userModel = manager.RetrieveUser(emailAddress);

                bool result = passwordManager.IsPasswordMatch(passwordHash, userModel.Salt, userModel.PasswordHash);

                if (result)
                {
                    if (ModelState.IsValid)
                    {
                        Session["CurrentUserID"] = userModel.Username;
                        Session["CurrentUser"] = userModel;

                        return RedirectToAction("Index", "Home", userModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("PasswordHash", "Incorrect Password");
                }
            }
            else
            {
                ModelState.AddModelError("EmailAddress", "Email Address doesn't match any account");
            }

            return View("LogIn");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn");
        }

        public JsonResult CheckEmail(string emailAddress)
        {
            bool result = manager.CheckEmailAddress(emailAddress);
            return Json(new { Result = result });
        }

        public JsonResult CheckUsername(string username)
        {
            bool result = manager.CheckUsername(username);
            return Json(new { Result = result });
        }
    }
}