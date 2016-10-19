using PastebookBusinessLogic.BusinessLogic;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class UserController : Controller
    {
        LogInRegisterManager manager = new LogInRegisterManager();

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Countries = manager.RetrieveAllCountries();

            if (Session["CurrentUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
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
            if (Session["CurrentUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string emailAddress, string passwordHash)
        {
            if (manager.CheckEmailAddress(emailAddress))
            {
                UserModel userModel = new UserModel();

                userModel = manager.RetrieveUser(emailAddress);

                bool result = manager.CheckPassword(passwordHash, userModel.Salt, userModel.PasswordHash);

                if (result)
                {
                    if (ModelState.IsValid)
                    {
                        Session["CurrentUser"] = userModel.EmailAddress;
                        Session["FirstName"] = userModel.FirstName;
                        return RedirectToAction("Index", "Home");
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
            Response.Redirect(Url.Action("LogIn"));
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