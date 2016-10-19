using PastebookBusinessLogic.BusinessLogic;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class HomeController : Controller
    {
        LogInRegisterManager manager = new LogInRegisterManager();

        //newsfeed
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null)
            {
                return View();
            }

            return RedirectToAction("LogIn", "User");
        }

        //profile
        public ActionResult UserProfile(string username)
        {
            if (Session["CurrentUser"] != null)
            {
                string email = (string)Session["CurrentUser"];
                UserModel userModel = manager.RetrieveUser(email);

                return View("Profile", userModel);
            }

            return RedirectToAction("LogIn", "User");
        }
    }
}