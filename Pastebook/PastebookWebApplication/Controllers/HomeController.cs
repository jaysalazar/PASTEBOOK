using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
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
            if (Session["CurrentUser"] != null)
            {
                // retrieve current user
                string username = (string)Session["CurrentUser"];

                // save to userModel
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                userModel = userManager.RetrieveUser(username);

                PastebookModel model = new PastebookModel();

                model.UserEntity = userModel;

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult NewsFeed(int id)
        {
            List<PB_POST> posts = new List<PB_POST>();
            PostManager postManager = new PostManager();

            PB_FRIEND friendModel = new PB_FRIEND
            {
                USER_ID = id
            };

            posts = postManager.RetrievePostToNewsFeed(friendModel);

            return PartialView(posts);
        }
    }
}