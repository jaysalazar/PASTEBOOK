using PastebookWebApplication.Managers;
using PastebookWebApplication.Mappers;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class HomeController : Controller
    {
        LogInRegisterManager userManager = new LogInRegisterManager();
        ProfileManager postManager = new ProfileManager();

        //newsfeed
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null)
            {
                return View();
            }

            return RedirectToAction("LogIn", "User");
        }

        //profile
        [HttpGet]
        public ActionResult UserProfile(string username)
        {
            if (Session["CurrentUser"] != null)
            {
                string email = (string)Session["CurrentUser"];
                UserProfileModel profileModel = new UserProfileModel();

                UserModel userModel = new UserModel();
                userModel = userManager.RetrieveUser(email);

                profileModel.User = userModel;

                return View(profileModel);
            }

            return RedirectToAction("LogIn", "User");
        }

        [HttpPost]
        public ActionResult Timeline(UserProfileModel profileModel)
        {
            //string email = (string)Session["CurrentUser"];

            //UserModel userModel = new UserModel();
            //userModel = manager.RetrieveUser(email);

            if (Session["CurrentUser"] != null)
            {
                PostModel postModel = new PostModel()
                {
                    PosterId = profileModel.User.UserId,
                    ProfileOwnerId = profileModel.User.UserId,
                    Content = profileModel.Post.Content
                };

                postManager.CreatePost(postModel);
                //ViewBag.Posts = postManager.RetrieveAllPosts();

                return View(postModel);
            }

            return RedirectToAction("LogIn", "User");
        }
    }
}