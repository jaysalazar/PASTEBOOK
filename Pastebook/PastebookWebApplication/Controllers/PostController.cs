using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class PostController : Controller
    {
        // site/Posts/postID
        //public ActionResult Posts(int postID)
        //{
        //    if (Session["CurrentUserID"] != null)
        //    {
        //        PostManager postManager = new PostManager();
        //        UserManager userManager = new UserManager();
        //        PB_POST postEntity = new PB_POST();
        //        PB_USER userEntity = new PB_USER();
               
        //        //retrieve post from postID
        //        postEntity = postManager.RetrievePost(postID);

        //        //retrieve details of poster
        //        userEntity = userManager.RetrieveUserByID(postEntity.POSTER_ID);

        //        //get selected details to view
        //        PostModel postModel = new PostModel
        //        {
        //            PostID = postEntity.ID,
        //            CreatedDate = postEntity.CREATED_DATE,
        //            ProfileOwnerID = postEntity.PROFILE_OWNER_ID,
        //            PosterFirstName = userEntity.FIRST_NAME,
        //            PosterLastName = userEntity.LAST_NAME,
        //            PosterProfilePicture = userEntity.PROFILE_PIC,
        //            PosterUsername = userEntity.USER_NAME,
        //            Content = postEntity.CONTENT
        //        };

        //        return View(postModel);
        //    }

        //    return RedirectToAction("LogIn", "Account");
        //}
    }
}