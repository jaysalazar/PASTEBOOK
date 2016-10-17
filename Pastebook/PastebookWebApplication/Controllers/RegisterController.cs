using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class RegisterController : Controller
    {
        PasteBookManager manager = new PasteBookManager();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public JsonResult RegisterUser(string username, string password)
        {
            UserModel userModel = new UserModel()
            {
                Username = username,
                PasswordHash = password
            };

            int result = manager.CreateUser(userModel);

            return Json(new { Result = result });
        }
    }
}