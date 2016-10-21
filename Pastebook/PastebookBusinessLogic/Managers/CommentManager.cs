using PastebookDataAccess;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class CommentManager : Repository<PASTEBOOK_DBEntities, PB_COMMENT>
    {
        public int AddComment(PB_COMMENT commentEntity)
        {
            int result = 0;

            try
            {
                result = Add(commentEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public List<PB_COMMENT> RetrieveComments(int postId)
        {
            List<PB_COMMENT> comments = new List<PB_COMMENT>();

            try
            {
                var result = Retrieve(x => x.POST_ID == postId);

                foreach (var comment in result)
                {
                    comments.Add(comment);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return comments;
        }
    }
}