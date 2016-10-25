using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // site/
        public ActionResult Index()
        {
            // if a user is logged in go to home
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                // retrieve current user
                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                return View(userModel);
            }

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult NewsFeed(int userID)
        {
            List<UserPostViewModel> modelList = new List<UserPostViewModel>();
            RetrieveManager manager = new RetrieveManager();

            modelList = manager.RetrievePosts(userID);

            return PartialView(modelList);
        }

        public JsonResult CreatePost(string content)
        {
            PostManager postManager = new PostManager();

            PB_POST post = new PB_POST
            {
                POSTER_ID = (int)Session["CurrentUserID"],
                PROFILE_OWNER_ID = (int)Session["CurrentUserID"],
                CONTENT = content
            };

            var result = postManager.CreatePost(post);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}