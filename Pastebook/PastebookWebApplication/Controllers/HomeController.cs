using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // site/
        public ActionResult Index()
        {
            // if a user is logged in go to home
            if (Session["CurrentUser"] != null)
            {
                return View();
            }

            return RedirectToAction("LogIn", "Account");
        }
    }
}