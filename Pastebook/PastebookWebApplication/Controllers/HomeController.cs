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
                UserManager userManager = new UserManager();
                PB_USER userModel = new PB_USER();
                PastebookModel model = new PastebookModel();

                // retrieve current user
                string username = (string)Session["CurrentUser"];
                userModel = userManager.RetrieveUser(username);
                // save to userModel
                model.UserEntity = userModel;

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult NewsFeed(int id)
        {

            PostManager postManager = new PostManager();
            FriendManager friendManager = new FriendManager();
            List<PB_POST> posts = new List<PB_POST>();
            List<PB_FRIEND> friends = new List<PB_FRIEND>();

            friends = friendManager.RetrieveAllFriends(id);

            foreach (var friend in friends)
            {
                posts = postManager.RetrievePostToNewsFeed(friend);
            }

            return PartialView(posts);
        }
    }
}