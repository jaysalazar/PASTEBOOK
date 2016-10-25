using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class LikeManager : Repository<PB_LIKE>
    {
        public int Like(PB_LIKE likeEntity)
        {
            int result = Add(likeEntity);

            if (result == 1)
            {
                result = CountLikes(likeEntity.POST_ID);
            }

            return result;
        }

        public int Unlike(PB_LIKE likeEntity)
        {
            int result = Delete(likeEntity);
            return result;
        }

        public int CountLikes(int postID)
        {
            int result = Retrieve(x => x.POST_ID == postID).Count();
            return result;
        }

        public List<PB_LIKE> RetrieveLikes(int postID)
        {
            List<PB_LIKE> likes = new List<PB_LIKE>();
            likes = Retrieve(x => x.POST_ID == postID);
            return likes;
        }
    }
}
