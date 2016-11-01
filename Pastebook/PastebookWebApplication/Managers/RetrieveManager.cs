using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections.Generic;

namespace PastebookWebApplication.Managers
{
    public class RetrieveManager
    {
        public List<PostViewModel> RetrievePosts(int userID)
        {
            List<PostViewModel> postModelList = new List<PostViewModel>();
            List<PB_FRIEND> friends = new List<PB_FRIEND>();
            List<PB_POST> posts = new List<PB_POST>();
            PB_USER userModel = new PB_USER();
            UserManager userManager = new UserManager();
            FriendManager friendManager = new FriendManager();
            PostManager postManager = new PostManager();

            friends = friendManager.RetrieveFriends(userID);

            if (friends == null || friends.Count == 0)
            {
                posts = postManager.RetrievePostsOfUser(userID);
            }
            else
            {
                posts = postManager.RetrievePosts(friends);
            }

            foreach (var post in posts)
            {
                userModel = userManager.RetrieveUserByID(post.POSTER_ID);

                postModelList.Add(new PostViewModel
                {
                    User = userModel,
                    Post = post
                });
            }

            return postModelList;
        }

        //public List<ActionViewModel> RetrieveComment(int postID)
        //{
        //    List<ActionViewModel> modelList = new List<ActionViewModel>();

        //    List<PB_COMMENT> comments = new List<PB_COMMENT>();
        //    PB_COMMENT commentModel = new PB_COMMENT();
        //    CommentManager commentManager = new CommentManager();

        //    PB_USER userModel = new PB_USER();
        //    UserManager userManager = new UserManager();

        //    // retrieve comments from post
        //    comments = commentManager.RetrieveComments(postID);

        //    foreach (var comment in comments)
        //    {
        //        //retrieve commenter details
        //        userModel = userManager.RetrieveUserByID(comment.POSTER_ID);

        //        modelList.Add(new ActionViewModel
        //        {
        //            User = userModel,
        //            Comment = comment,
        //            PostID = postID
        //        });
        //    }

        //    return modelList;
        //}
    }
}