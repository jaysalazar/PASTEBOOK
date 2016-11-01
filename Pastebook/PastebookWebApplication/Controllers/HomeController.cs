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
        //[Route("")]
        public ActionResult Index()
        {
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();
                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                return View(userModel);
            }

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult NewsFeed()
        {
            if (Session["CurrentUserID"] != null)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();
                RetrieveManager manager = new RetrieveManager();
                int userID = (int)Session["CurrentUserID"];
                return PartialView(manager.RetrievePosts(userID));
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpGet]
        public ActionResult Settings()
        {
            if (Session["CurrentUserID"] != null)
            {
                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();
                countries = countryManager.Retrieve();

                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                RegisterViewModel model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries
                };

                return View(model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult EditInformation(RegisterViewModel model)
        {
            if (Session["CurrentUserID"] != null)
            {
                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();
                countries = countryManager.Retrieve();

                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                if (userManager.CheckUsername(model.User.USER_NAME) == true)
                {
                    ModelState.AddModelError("User.USER_NAME", "Username is already taken");
                    model = new RegisterViewModel
                    {
                        User = userModel,
                        Countries = countries
                    };

                    return View("Settings", model);
                }

                userModel.USER_NAME = model.User.USER_NAME;
                userModel.FIRST_NAME = model.User.FIRST_NAME;
                userModel.LAST_NAME = model.User.LAST_NAME;
                userModel.GENDER = model.User.GENDER;
                userModel.BIRTHDAY = model.User.BIRTHDAY;
                userModel.COUNTRY_ID = model.User.COUNTRY_ID;
                userModel.MOBILE_NO = model.User.MOBILE_NO;

                int result = userManager.UpdateUser(userModel);

                model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries
                };

                return View("Settings", model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult EditEmail(RegisterViewModel model)
        {
            if (Session["CurrentUserID"] != null)
            {
                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();
                countries = countryManager.Retrieve();

                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                if (userManager.CheckEmailAddress(model.User.EMAIL_ADDRESS) == true)
                {
                    ModelState.AddModelError("User.EMAIL_ADDRESS", "Email is already taken");
                    model = new RegisterViewModel
                    {
                        User = userModel,
                        Countries = countries
                    };

                    return View("Settings", model);
                }

                if (userManager.CheckPassword(userModel.EMAIL_ADDRESS, model.User.PASSWORD) == false)
                {
                    ModelState.AddModelError("User.PASSWORD", "Incorrect Password");
                    model = new RegisterViewModel
                    {
                        User = userModel,
                        Countries = countries
                    };

                    return View("Settings", model);
                }

                userModel.EMAIL_ADDRESS = model.User.EMAIL_ADDRESS;
                int result = userManager.UpdateUser(userModel);

                model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries,
                };

                return View("Settings", model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult EditPassword(RegisterViewModel model)
        {
            if (Session["CurrentUserID"] != null)
            {
                List<REF_COUNTRY> countries = new List<REF_COUNTRY>();
                CountryManager countryManager = new CountryManager();
                countries = countryManager.Retrieve();

                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                int userID = (int)Session["CurrentUserID"];
                userModel = userManager.RetrieveUserByID(userID);

                if (userManager.CheckPassword(userModel.EMAIL_ADDRESS, model.User.PASSWORD) == false)
                {
                    ModelState.AddModelError("User.PASSWORD", "Incorrect Password");
                    model = new RegisterViewModel
                    {
                        User = userModel,
                        Countries = countries
                    };

                    return View("Settings", model);
                }

                PasswordManager passwordManager = new PasswordManager();
                string salt = "";

                userModel.PASSWORD = passwordManager.GeneratePasswordHash(model.User.PASSWORD, out salt);
                userModel.SALT = salt;

                int result = userManager.UpdateUser(userModel);

                model = new RegisterViewModel
                {
                    User = userModel,
                    Countries = countries,
                };

                return View("Settings", model);
            }

            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            List<PB_USER> users = new List<PB_USER>();
            UserManager userManager = new UserManager();

            users = userManager.SearchUsers(name);

            return View("Search", users);
        }

        public JsonResult CreatePost(string content)
        {
            PostManager postManager = new PostManager();
            int userID = (int)Session["CurrentUserID"];

            PB_POST post = new PB_POST
            {
                POSTER_ID = userID,
                PROFILE_OWNER_ID = userID,
                CONTENT = content
            };

            int result = postManager.CreatePost(post);

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateComment(int postID, string content)
        {
            CommentManager commentManager = new CommentManager();
            int userID = (int)Session["CurrentUserID"];

            PB_COMMENT comment = new PB_COMMENT
            {
                POST_ID = postID,
                POSTER_ID = userID,
                CONTENT = content
            };

            int result = commentManager.CreateComment(comment);

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddLike(int postID)
        {
            LikeManager likeManager = new LikeManager();
            PB_LIKE like = new PB_LIKE();

            like.POST_ID = postID;

            int result = likeManager.Like(like);

            return Json(new { Result = result });
        }
    }
}