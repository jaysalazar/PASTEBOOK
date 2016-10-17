using PastebookBusinessLogic.BusinessLogic;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class LogInController : Controller
    {
        PasteBookManager pastebookManager = new PasteBookManager();
        PasswordManager passwordManager = new PasswordManager();

        public ActionResult LogIn()
        {
            return View();
        }

        public JsonResult LogInUser(string username, string password)
        {
            UserModel userModel = new UserModel();

            userModel = pastebookManager.RetrieveUser(username);
            
            bool result = false;

            //trace code
            //Session["SessionUserID"] = userModel.Username;

            if (userModel != null)
            {
                //Session["userNameSession"] = userModel;
                result = passwordManager.IsPasswordMatch(password, userModel.Salt, userModel.PasswordHash);
            }

            return Json(new { Result = result });
        }
    }
}