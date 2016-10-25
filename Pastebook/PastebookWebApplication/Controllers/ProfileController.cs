//using PastebookBusinessLogic.Managers;
//using PastebookEntityFramework;
//using PastebookWebApplication.Models;
//using System.Collections.Generic;
//using System.Web.Mvc;

//namespace PastebookWebApplication.Controllers
//{
//    public class ProfileController : Controller
//    {
//        // site/username
//        public ActionResult Index(string username)
//        {
//            if (Session["CurrentUserID"] != null)
//            {
//                // TODO:
//                // get email of current user
//                // try to implement friend profile page
//                // get any profile of any user using username and save as profile owner id

//                // saved current user for the mean time
//                int userID = (int)Session["CurrentUserID"];

//                UserPostViewModel profileModel = new UserPostViewModel();

//                PB_USER userModel = new PB_USER();
//                UserManager userManager = new UserManager();
//                userModel = userManager.RetrieveUserByID(userID);

//                // save user creds to profileModel view to provide info for profile
//                profileModel.UserEntity = userModel;

//                return View(profileModel);
//            }

//            return RedirectToAction("LogIn", "Account");
//        }
        
//        public ActionResult Timeline(UserPostViewModel profileModel)
//        {
//            if (Session["CurrentUser"] != null)
//            {
//                // save post on postModel
//                PB_POST postModel = new PB_POST()
//                {
//                    POSTER_ID = profileModel.UserEntity.ID,
//                    // temp POID: current user
//                    // TODO: /{username}
//                    PROFILE_OWNER_ID = profileModel.UserEntity.ID,
//                    CONTENT = profileModel.PostEntity.CONTENT
//                };

//                // save post to DB
//                PostManager postManager = new PostManager();

//                postManager.CreatePost(postModel);

//                // retrieve current user email
//                int userID = (int)Session["CurrentUserID"];

//                // save to userModel
//                PB_USER userModel = new PB_USER();
//                UserManager userManager = new UserManager();
//                userModel = userManager.RetrieveUserByID(userID);

//                List<PB_POST> posts = new List<PB_POST>();

//                posts = postManager.RetrievePostsOfUser(userID);

//                return View(posts);
//            }

//            return RedirectToAction("LogIn", "Account");
//        }
//    }
//}