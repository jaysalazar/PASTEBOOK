using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Managers
{
    public class RetrieveManager
    {
        public List<PostViewModel> RetrievePosts(int userID)
        {
            List<PostViewModel> modelList = new List<PostViewModel>();
            List<PB_FRIEND> friends = new List<PB_FRIEND>();
            FriendManager friendManager = new FriendManager();

            List<PB_POST> posts = new List<PB_POST>();
            PostManager postManager = new PostManager();

            PB_USER userModel = new PB_USER();
            UserManager userManager = new UserManager();

            // retrieve user's friends
            friends = friendManager.RetrieveFriends(userID);

            // if user has no friend/s
            if (friends == null)
            {
                posts = postManager.RetrievePostsOfUser(userID);
            }
            else
            {
                posts = postManager.RetrievePosts(friends);
            }

            foreach (var post in posts)
            {
                // retrieve details of poster
                userModel = userManager.RetrieveUserByID(post.POSTER_ID);

                // add to view model
                modelList.Add(new PostViewModel
                {
                    User = userModel,
                    Post = post
                });
            }

            return modelList;
        }

        public List<ActionViewModel> RetrieveComment(int postID)
        {
            List<PB_COMMENT> comments = new List<PB_COMMENT>();
            PB_COMMENT commentModel = new PB_COMMENT();
            CommentManager commentManager = new CommentManager();

            PB_USER userModel = new PB_USER();
            UserManager userManager = new UserManager();

            List<ActionViewModel> modelList = new List<ActionViewModel>();

            // retrieve comments from post
            comments = commentManager.RetrieveComments(postID);

            foreach (var comment in comments)
            {
                //retrieve commenter details
                userModel = userManager.RetrieveUserByID(comment.POSTER_ID);

                modelList.Add(new ActionViewModel
                {
                    User = userModel,
                    Comment = commentModel
                });
            }

            return modelList;
        }
    }
}