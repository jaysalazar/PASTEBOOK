using PastebookBusinessLogic.Managers;
using PastebookDataAccess;
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
        public ActionResult Index(string emailAddress, string password)
        {
            if (userManager.CheckEmailAddress(emailAddress))
            {
                PB_USER userModel = new PB_USER();

                userModel = userManager.RetrieveUserByEmail(emailAddress);

                bool result = userManager.CheckPassword(password, userModel.SALT, userModel.PASSWORD);

                if (result)
                {
                    if (ModelState.IsValid)
                    {
                        Session["CurrentUser"] = userModel.EMAIL_ADDRESS;
                        Session["FirstName"] = userModel.FIRST_NAME;
                        Session["Username"] = userModel.USER_NAME;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("PasswordHash", "Incorrect Password.");
                }
            }
            else
            {
                ModelState.AddModelError("EmailAddress", "Email doesn't match any account.");
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
    }
}