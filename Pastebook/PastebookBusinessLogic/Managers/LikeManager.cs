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
            Add(likeEntity);
            return Count(x => x.POST_ID == likeEntity.POST_ID);
        }

        public int Unlike(PB_LIKE likeEntity)
        {
            Delete(likeEntity);
            return Count(x => x.POST_ID == likeEntity.POST_ID);
        }

        //public List<PB_LIKE> RetrieveLikes(int postID)
        //{
        //    List<PB_LIKE> likes = new List<PB_LIKE>();
        //    likes = Retrieve(x => x.POST_ID == postID);
        //    return likes;
        //}
    }
}
