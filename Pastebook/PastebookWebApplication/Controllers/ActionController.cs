using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Comment(int postID)
        {
            List<ActionViewModel> modelList = new List<ActionViewModel>();
            RetrieveManager manager = new RetrieveManager();

            modelList = manager.RetrieveComment(postID);

            return PartialView(modelList);
        }

        public ActionResult Like(int postID)
        {
            List<ActionViewModel> modelList = new List<ActionViewModel>();

            List<PB_LIKE> likes = new List<PB_LIKE>();
            LikeManager likeManager = new LikeManager();

            likes = likeManager.RetrieveLikes(postID);

            foreach (var like in likes)
            {
                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                // retrieve users who likes the post
                userModel = userManager.RetrieveUserByID(like.LIKED_BY);

                modelList.Add(new ActionViewModel
                {
                    User = userModel,
                    Like = like
                });
            }
            
            return PartialView(modelList);
        }

        public JsonResult AddLike(int postID, int likedBy)
        {
            LikeManager likeManager = new LikeManager();

            PB_LIKE like = new PB_LIKE
            {
                POST_ID = postID,
                LIKED_BY = likedBy
            };

            // number of likes
            int result = likeManager.Like(like);

            return Json(new { Result = result });
        }

        public JsonResult CreateComment(int postID, int posterID, string content)
        {
            CommentManager commentManager = new CommentManager();

            PB_COMMENT comment = new PB_COMMENT
            {
                POST_ID = postID,
                POSTER_ID = posterID,
                CONTENT = content
            };

            int result = commentManager.CreateComment(comment);

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}