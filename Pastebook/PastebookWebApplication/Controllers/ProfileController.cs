using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class ProfileController : Controller
    {
        [Route("{username}")]
        public ActionResult Index(string username)
        {
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();

                userModel = userManager.RetrieveSpecific(x => x.USER_NAME == username);
                countries = countryManager.Retrieve();

                RegisterViewModel model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries
                };

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult Timeline(int userID)
        {
            List<PostViewModel> modelList = new List<PostViewModel>();
            List<PB_POST> posts = new List<PB_POST>();
            PB_USER userModel = new PB_USER();
            PostManager postManager = new PostManager();
            UserManager userManager = new UserManager();

            posts = postManager.RetrievePostsOfUser(userID);

            foreach (var post in posts)
            {
                userModel = userManager.RetrieveUserByID(post.POSTER_ID);
                
                modelList.Add(new PostViewModel
                {
                    User = userModel,
                    Post = post
                });
            }

            return PartialView(modelList);
        }
    }
}