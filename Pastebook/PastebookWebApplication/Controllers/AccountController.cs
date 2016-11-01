using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["CurrentUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
            CountryManager countryManager = new CountryManager();
            countries = countryManager.Retrieve();

            RegisterViewModel model = new RegisterViewModel
            {
                Countries = countries
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
            CountryManager countryManager = new CountryManager();
            countries = countryManager.Retrieve();

            UserManager userManager = new UserManager();

            if (userManager.CheckEmailAddress(model.User.EMAIL_ADDRESS) == true)
            {
                ModelState.AddModelError("EMAIL_ADDRESS", "Email is already taken");
                return View();
            }
            else if (userManager.CheckUsername(model.User.USER_NAME) == true)
            {
                ModelState.AddModelError("USER_NAME", "Username is already taken");
                return View();
            }
            else
            {
                userManager.CreateUser(model.User);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            if (Session["CurrentUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(PB_USER userModel)
        {
            UserManager userManager = new UserManager();

            if (userManager.CheckPassword(userModel.EMAIL_ADDRESS, userModel.PASSWORD) == true)
            {
                userModel = userManager.RetrieveUserByEmail(userModel.EMAIL_ADDRESS);
                Session["CurrentUserID"] = userModel.ID;
                Session["Username"] = userModel.USER_NAME;
                Session["FirstName"] = userModel.FIRST_NAME;

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("PASSWORD", "Email or Password is entered incorrectly.");
            
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return View("LogIn");
        }

        public JsonResult CheckEmail(string email)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.CheckEmailAddress(email);
            return Json(new { Result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUsername(string username)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.CheckUsername(username);
            return Json(new { Result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckPassword(string email, string password)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.CheckPassword(email, password);
            return Json(new { Result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}