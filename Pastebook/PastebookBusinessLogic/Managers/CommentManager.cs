using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class CommentManager : Repository<PB_COMMENT>
    {
        public int AddComment(PB_COMMENT commentModel)
        {
            int result = Add(commentModel);

            return result;
        }

        public List<PB_COMMENT> RetrieveComments(int postID)
        {
            List<PB_COMMENT> comments = new List<PB_COMMENT>();

            comments = Retrieve(x => x.POST_ID == postID);

            return comments;
        }
    }
}