using PastebookBusinessLogic.Entities;
using PastebookBusinessLogic.Mappers;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class PostManager
    {
        List<Exception> exceptionList;
        
        public int CreatePost(PostEntity postEntityUI)
        {
            int result = 0;
            PB_POST postEntityEF = new PB_POST();

            postEntityEF = PostMapper.MapPostEntityUIToPostEntityEF(postEntityUI);
            postEntityEF.CREATED_DATE = DateTime.UtcNow;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.PB_POST.Add(postEntityEF);
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public PostEntity RetrievePost(int posterId)
        {
            PostEntity postEntityUI = new PostEntity();
            PB_POST postEntityEF = new PB_POST();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    postEntityEF = context.PB_POST.Single(x => x.POSTER_ID == posterId);
                    postEntityUI = PostMapper.MapPostEntityEFToPostEntityUI(postEntityEF);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return postEntityUI;
        }
    }
}
