using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class LikeManager : Repository<PASTEBOOK_DBEntities, PB_LIKE>
    {
        public int Like(PB_LIKE likeEntity)
        {
            int result = 0;

            try
            {
                result = Add(likeEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public int Unlike(PB_LIKE likeEntity)
        {
            int result = 0;

            try
            {
                result = Delete(likeEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public int CountLikes(int postId)
        {
            int result = 0;

            try
            {
                result = Retrieve(x => x.POST_ID == postId).Count();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }


        public List<PB_LIKE> RetrieveLikes(int postId)
        {
            List<PB_LIKE> likes = new List<PB_LIKE>();

            try
            {
                var result = Retrieve(x => x.POST_ID == postId);

                foreach (var like in result)
                {
                    likes.Add(like);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return likes;
        }
    }
}
