using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class AccountController : Controller
    {
        // site/
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["CurrentUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
            CountryManager countryManager = new CountryManager();
            UserManager userManager = new UserManager();

            countries = countryManager.RetrieveAllCountries();

            RegisterViewModel model = new RegisterViewModel
            {
                Countries = countries
            };

            return View(model);
        }

        // TODO: fix this
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
            //CountryManager countryManager = new CountryManager();
            UserManager userManager = new UserManager();

            //countries = countryManager.RetrieveAllCountries();

            // check any existing email
            if (userManager.CheckEmailAddress(model.User.EMAIL_ADDRESS) == true)
            {
                ModelState.AddModelError("EMAIL_ADDRESS", "Email is already taken");
                return View();
            }

            // check any existing username
            if (userManager.CheckUsername(model.User.USER_NAME) == true)
            {
                ModelState.AddModelError("USER_NAME", "Username is already taken");
                return View();
            }

            // confirm password
            if (userManager.ConfirmPassword(model.User.PASSWORD, model.ConfirmPassword) == false)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
                return View();
            }

            if (ModelState.IsValid)
            {
                userManager.CreateUser(model.User);
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        // site/
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

            if (userManager.CheckEmailAddress(userModel.EMAIL_ADDRESS))
            {
                bool result = userManager.CheckPassword(userModel.EMAIL_ADDRESS, userModel.PASSWORD);

                if (result == true)
                {
                    // get user data
                    userModel = userManager.RetrieveUserByEmail(userModel.EMAIL_ADDRESS);
                    Session["CurrentUserID"] = userModel.ID;
                    Session["Username"] = userModel.USER_NAME;
                    Session["FirstName"] = userModel.FIRST_NAME;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("PASSWORD", "Incorrect Password");
                }
            }
            else
            {
                ModelState.AddModelError("EMAIL_ADDRESS", "Email doesn't match any account");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Response.Redirect(Url.Action("LogIn"));
            return View("LogIn");
        }

        public JsonResult CheckEmail(string emailAddress)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.CheckEmailAddress(emailAddress);
            return Json(new { Result = result });
        }

        public JsonResult CheckUsername(string username)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.CheckUsername(username);
            return Json(new { Result = result });
        }

        public JsonResult ConfirmPassword(string password, string confirmPassword)
        {
            UserManager userManager = new UserManager();
            bool result = userManager.ConfirmPassword(password, confirmPassword);
            return Json(new { Result = result });
        }
    }
}