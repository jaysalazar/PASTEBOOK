using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class PostManager : Repository<PASTEBOOK_DBEntities, PB_POST>
    {
        public int CreatePost(PB_POST postEntity)
        {
            int result = 0;

            postEntity.CREATED_DATE = DateTime.UtcNow;

            try
            {
                result = Add(postEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        // todo: try to view timeline of a friend from the current user acct
        public List<PB_POST> RetrievePostToTimeline(PB_USER userEntity)
        {
            List<PB_POST> posts = new List<PB_POST>();
            PB_POST postEntity = new PB_POST();

            try
            {
                // timeline: retrieves all posts of user and friends who posts to user's profile
                var result = Retrieve(x => x.PROFILE_OWNER_ID == userEntity.ID)
                            .OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();

                foreach (var post in result)
                {
                    post.CREATED_DATE = post.CREATED_DATE.ToLocalTime();
                    posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return posts;
        }

        public List<PB_POST> RetrievePostToNewsFeed(PB_FRIEND friendEntity)
        {
            List<PB_POST> posts = new List<PB_POST>();
            PB_POST postEntity = new PB_POST();

            try
            {
                // newsfeed: retrieves all posts of user and friends of user
                var result = Retrieve(x => x.POSTER_ID == friendEntity.USER_ID || x.POSTER_ID == friendEntity.FRIEND_ID)
                            .OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();

                foreach (var post in result)
                {
                    post.CREATED_DATE = post.CREATED_DATE.ToLocalTime();
                    posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return posts;
        }

        public PB_POST RetrievePost(int postId)
        {
            PB_POST postEntity = new PB_POST();

            try
            {
                postEntity = Retrieve(x => x.ID == postId).Single();
                postEntity.CREATED_DATE = postEntity.CREATED_DATE.ToLocalTime();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return postEntity;
        }
    }
}