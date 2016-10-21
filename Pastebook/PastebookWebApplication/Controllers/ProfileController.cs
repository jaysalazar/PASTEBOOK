using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class ProfileController : Controller
    {
        UserManager userManager = new UserManager();

        // site/username
        [HttpGet]
        public ActionResult Index(string username)
        {
            if (Session["CurrentUser"] != null)
            {
                // TODO:
                // get email of current user
                // try to implement friend profile page
                // get any profile of any user using username and save as profile owner id

                // saved current user for the mean time
                string username1 = (string)Session["CurrentUser"];

                PastebookModel profileModel = new PastebookModel();

                PB_USER userModel = new PB_USER();

                userModel = userManager.RetrieveUser(username1);

                // save user creds to profileModel view to provide info for profile
                profileModel.UserEntity = userModel;

                return View(profileModel);
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Timeline(PastebookModel profileModel)
        {
            if (Session["CurrentUser"] != null)
            {
                // save post on postModel
                PB_POST postModel = new PB_POST()
                {
                    POSTER_ID = profileModel.UserEntity.ID,
                    // temp POID: current user
                    // TODO: /{username}
                    PROFILE_OWNER_ID = profileModel.UserEntity.ID,
                    CONTENT = profileModel.PostEntity.CONTENT
                };

                // save post to DB
                PostManager postManager = new PostManager();

                postManager.CreatePost(postModel);

                // retrieve current user email
                string username = (string)Session["CurrentUser"];

                // save to userModel
                PB_USER userModel = new PB_USER();
                userModel = userManager.RetrieveUser(username);

                List<PB_POST> posts = new List<PB_POST>();

                posts = postManager.RetrievePostToTimeline(userModel);

                return View(posts);
            }

            return RedirectToAction("LogIn", "Account");
        }
    }
}