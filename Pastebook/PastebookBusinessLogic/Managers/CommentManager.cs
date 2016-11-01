using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class CommentManager : Repository<PB_COMMENT>
    {
        public int CreateComment(PB_COMMENT commentModel)
        {
            commentModel.DATE_CREATED = DateTime.UtcNow;
            return Add(commentModel);
        }

        //public List<PB_COMMENT> RetrieveComments(int postID)
        //{
        //    List<PB_COMMENT> comments = new List<PB_COMMENT>();

        //    comments = Retrieve();

        //    return comments;
        //}
    }
}