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
            List<PostViewModel> modelList = new List<PostViewModel>();
            RetrieveManager manager = new RetrieveManager();

            modelList = manager.RetrievePosts(userID);

            return PartialView(modelList);
        }

        // get current users info to display on view
        [HttpGet]
        public ActionResult Settings()
        {
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();

                int ID = (int)Session["CurrentUserID"];

                userModel = userManager.RetrieveUserByID(ID);
                countries = countryManager.RetrieveAllCountries();

                RegisterViewModel model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries
                };

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        // applying changes made on view
        [HttpPost]
        public ActionResult Settings(RegisterViewModel model)
        {
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();

                int userID = (int)Session["CurrentUserID"];

                userModel = userManager.RetrieveUserByID(userID);
                countries = countryManager.RetrieveAllCountries();

                // compare old and new userModels to see if there is change on values
                //test
                //var result = userModel.Equals(model);

                if ((userModel.USER_NAME == model.User.USER_NAME &&
                    userModel.FIRST_NAME == model.User.FIRST_NAME &&
                    userModel.LAST_NAME == model.User.LAST_NAME &&
                    userModel.BIRTHDAY == model.User.BIRTHDAY &&
                    userModel.GENDER == model.User.GENDER &&
                    userModel.COUNTRY_ID == model.User.COUNTRY_ID &&
                    userModel.MOBILE_NO == model.User.MOBILE_NO) == true)
                {
                    model = new RegisterViewModel
                    {
                        Countries = countries
                    };
                    return View(model);
                }
                else
                {
                    int result = userManager.UpdateUser(model.User);

                    // if update is successful, display changes to view
                    if (result == 1)
                    {
                        model = new RegisterViewModel
                        {
                            User = model.User,
                            Countries = countries
                        };
                    }
                }

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
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

            int result = postManager.CreatePost(post);

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}