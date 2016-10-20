using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
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
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public List<PB_POST> RetrieveAllPosts(PB_FRIEND friendEntity)
        {
            List<PB_POST> posts = new List<PB_POST>();
            PB_POST postEntity = new PB_POST();

            try
            {
                // timeline = current user profile_owner_id
                // newsfeed = timeline || (friend poster_Id && user poster_Id)
                var result = Retrieve(x => x.PROFILE_OWNER_ID == friendEntity.USER_ID)
                            .OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();
                //(x.POSTER_ID == friendEntity.FriendId || //edit
                // x.POSTER_ID == friendEntity.UserId))

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
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return posts;
        }

        public PB_POST RetrievePost(int postId)
        {
            PB_POST postEntity = new PB_POST();

            try
            {
                postEntity = Retrieve(x => x.ID == postId).Single();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return postEntity;
        }
    }
}