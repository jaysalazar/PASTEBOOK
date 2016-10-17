using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class RegisterController : Controller
    {
        PasteBookManager manager = new PasteBookManager();
        LogInModel userModel;

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public JsonResult RegisterUser(string username, string password)
        {
            userModel = new LogInModel()
            {
                Username = username,
                PasswordHash = password
            };

            int result = manager.CreateUser(userModel);

            return Json(new { Result = result });
        }
    }
}