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
        public List<UserPostViewModel> RetrievePosts(int userID)
        {
            List<UserPostViewModel> modelList = new List<UserPostViewModel>();
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
                modelList.Add(new UserPostViewModel
                {
                    User = userModel,
                    Post = post
                });
            }

            return modelList;
        }
    }
}