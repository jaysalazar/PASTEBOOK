using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Managers;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class ActionController : Controller
    {
        //public ActionResult Actions(int postID, ActionViewModel model, string content)
        //{
        //    if (Session["CurrentUserID"] != null)
        //    {
        //        RetrieveManager manager = new RetrieveManager();
        //        CommentManager commentManager = new CommentManager();
        //        List<ActionViewModel> modelList = new List<ActionViewModel>();

        //        model.PostID = postID;

        //        if (content != null)
        //        {
        //            model.Comment.CONTENT = content;
        //            var result = commentManager.CreateComment(model.Comment);

        //            if (result == 1)
        //            {
        //                modelList = manager.RetrieveComment(model.PostID);
        //            }
        //        }

        //        return PartialView(modelList);
        //    }

        //    return RedirectToAction("LogIn", "Account");
        //}

        //public ActionResult Like(int postID)
        //{
        //    if (Session["CurrentUserID"] != null)
        //    {

        //        List<ActionViewModel> modelList = new List<ActionViewModel>();

        //        List<PB_LIKE> likes = new List<PB_LIKE>();
        //        LikeManager likeManager = new LikeManager();

        //        likes = likeManager.RetrieveLikes(postID);

        //        foreach (var like in likes)
        //        {
        //            PB_USER userModel = new PB_USER();
        //            UserManager userManager = new UserManager();

        //            // retrieve users who likes the post
        //            userModel = userManager.RetrieveUserByID(like.LIKED_BY);

        //            modelList.Add(new ActionViewModel
        //            {
        //                User = userModel,
        //                Like = like
        //            });
        //        }

        //        return PartialView(modelList);
        //    }
        //    return RedirectToAction("LogIn", "Account");
        //}
    }
}