using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class HomeController : Controller
    {
        AccountManager accountManager = new AccountManager();
        ProfileManager profileManager = new ProfileManager();

        //newsfeed
        public ActionResult Index()
        {
            // if a user is logged in go to home
            if (Session["CurrentUser"] != null)
            {
                return View();
            }

            return RedirectToAction("LogIn", "User");
        }

        [HttpGet]
        public ActionResult UserProfile(string username)
        {
            if (Session["CurrentUser"] != null)
            {
                // get email of current user
                // TODO: try to implement friend profile page
                string email = (string)Session["CurrentUser"];
                UserProfileModel profileModel = new UserProfileModel();

                UserModel userModel = new UserModel();
                userModel = accountManager.RetrieveUser(email);

                // save to profileModel view to get user credentials of current profile page
                profileModel.User = userModel;

                return View(profileModel);
            }

            return RedirectToAction("LogIn", "User");
        }
        
        [HttpPost]
        public ActionResult Timeline(UserProfileModel profileModel)
        {
            if (Session["CurrentUser"] != null)
            {
                // save post on postModel
                PostModel postModel = new PostModel()
                {
                    PosterId = profileModel.User.UserId,
                    // temp POID: current user
                    // TODO: /{username}
                    ProfileOwnerId = profileModel.User.UserId,
                    Content = profileModel.Post.Content
                };

                // save post to DB
                profileManager.CreatePost(postModel);

                // retrieve current user email
                string email = (string)Session["CurrentUser"];

                // save to userModel
                UserModel userModel = new UserModel();
                userModel = accountManager.RetrieveUser(email);

                // get list of freinds of current user
                List<FriendModel> Friends = new List<FriendModel>();
                Friends = profileManager.RetrieveAllFriends(userModel.UserId);

                // get user and friend posts to be displayed to timeline
                List<PostModel> Posts = new List<PostModel>();

                foreach (var friend in Friends)
                {
                    Posts = profileManager.RetrieveAllPosts(friend);
                }

                return View(Posts);
            }

            return RedirectToAction("LogIn", "User");
        }
    }
}