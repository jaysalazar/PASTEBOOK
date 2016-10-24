using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class AccountController : Controller
    {
        CountryManager countryManager = new CountryManager();
        UserManager userManager = new UserManager();

        // site/
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["CurrentUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Countries = countryManager.RetrieveAllCountries();
            return View();
        }

        [HttpPost]
        public ActionResult Register(PB_USER userModel)
        {
            ViewBag.Countries = countryManager.RetrieveAllCountries();

            if (userManager.CheckEmailAddress(userModel.EMAIL_ADDRESS) == true)
            {
                ModelState.AddModelError("Email", "Email is already taken.");
                return View();
            }

            if (userManager.CheckUsername(userModel.USER_NAME) == true)
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return View();
            }

            if (ModelState.IsValid)
            {
                // TODO: go to home page. display success
                userManager.CreateUser(userModel);
                return RedirectToAction("LogIn");
            }

            return View();
        }

        // site/
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
        public ActionResult LogIn(LogInModel model)
        {
            if (userManager.CheckEmailAddress(model.Email))
            {
                PB_USER userModel = new PB_USER();

                userModel = userManager.RetrieveUserByEmail(model.Email);

                bool result = userManager.CheckPassword(model.Password, userModel.SALT, userModel.PASSWORD);

                if (result)
                {
                    if (ModelState.IsValid)
                    {
                        Session["CurrentUser"] = userModel.USER_NAME;
                        Session["FirstName"] = userModel.FIRST_NAME;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("User.PASSWORD", "Incorrect Password.");
                }
            }
            else
            {
                ModelState.AddModelError("User.EMAIL_ADDRESS", "Email doesn't match any account.");
            }

            return View("LogIn");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Response.Redirect(Url.Action("LogIn"));
            return View("LogIn");
        }

        public JsonResult CheckEmail(string emailAddress)
        {
            bool result = userManager.CheckEmailAddress(emailAddress);
            return Json(new { Result = result });
        }

        public JsonResult CheckUsername(string username)
        {
            bool result = userManager.CheckUsername(username);
            return Json(new { Result = result });
        }

        //public JsonResult ConfirmPassword(string password)
        //{
        //    bool result = userManager.CheckPassword(password);
        //    return Json(new { Result = result });
        //}
    }
}