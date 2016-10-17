using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class LogInController : Controller
    {
        LogInManager logInManager = new LogInManager();
        PasswordManager passwordManager = new PasswordManager();
        LogInModel userModel;

        public ActionResult LogIn()
        {
            return View();
        }

        // GET: LogIn
        public JsonResult LogIn(string username, string password)
        {
            userModel = new LogInModel()
            {
                Username = username,
                PasswordHash = password
            };

            //userModel.Username = username;
            //userModel.PasswordHash = password;

            int result = logInManager.CreateUser(userModel);

            return Json(new { Result = result });
        }

        public JsonResult GetUser(string username, string password)
        {
            userModel = new LogInModel();

            userModel = logInManager.RetrieveUser(username);
            
            bool result = false;

            //trace
            Session["SessionUserID"] = userModel.Username;

            if (userModel != null)
            {
                Session["userNameSession"] = userModel;
                result = passwordManager.IsPasswordMatch(password, userModel.Salt, userModel.PasswordHash);

            }

            return Json(new { Result = result });
        }

    }
}