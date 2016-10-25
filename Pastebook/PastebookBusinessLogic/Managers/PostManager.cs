using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class PostManager : Repository<PB_POST>
    {
        public int CreatePost(PB_POST postModel)
        {
            // set created date to UTC
            postModel.CREATED_DATE = DateTime.UtcNow;

            int result = Add(postModel);

            return result;
        }

        // timeline
        public List<PB_POST> RetrievePostsOfUser(int userID)
        {
            List<PB_POST> posts = new List<PB_POST>();

            // timeline: retrieves all posts of user and friends who posts to user's profile
            posts = Retrieve(x => x.PROFILE_OWNER_ID == userID);

            foreach (var post in posts)
            {
                post.CREATED_DATE = post.CREATED_DATE.ToLocalTime();
                posts.Add(post);
            }

            return posts;
        }

        // newsfeed
        public List<PB_POST> RetrievePosts(List<PB_FRIEND> friends)
        {
            List<PB_POST> posts = new List<PB_POST>();

            foreach (var friend in friends)
            {
                // newsfeed: retrieve posts of user and friends of user
                var result = Retrieve(x => (x.POSTER_ID == friend.USER_ID || x.POSTER_ID == friend.FRIEND_ID) &&
                                     (x.PROFILE_OWNER_ID == friend.USER_ID || x.PROFILE_OWNER_ID == friend.FRIEND_ID)).ToList();

                foreach (var post in result)
                {
                    post.CREATED_DATE = post.CREATED_DATE.ToLocalTime();
                    posts.Add(post);
                }
            }

            // sort by date > remove duplicate > get top 100
            posts = posts.OrderByDescending(x => x.CREATED_DATE).GroupBy(x => x.ID).Select(x => x.First()).Take(100).ToList();

            return posts;
        }

        public PB_POST RetrievePost(int postID)
        {
            PB_POST postModel = new PB_POST();

            postModel = RetrieveSpecific(x => x.ID == postID);
            postModel.CREATED_DATE = postModel.CREATED_DATE.ToLocalTime();

            return postModel;
        }
    }
}