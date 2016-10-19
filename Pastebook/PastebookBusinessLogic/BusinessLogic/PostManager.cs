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

        public List<PostEntity> RetrieveAllPosts(PostEntity postEntity, string postType)
        {
            List<PostEntity> postEntityList = new List<PostEntity>();
            //PostEntity postEntity = new PostEntity();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    if (postType == "timeline")
                    {

                    }
                    if (postType == "newsfeed")
                    {

                    }


                    var result = context.PB_POST.ToList();

                    foreach (var post in result)
                    {
                        postEntity = PostMapper.MapPostEntityEFToPostEntityUI(post);
                        postEntityList.Add(postEntity);
                    }
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return postEntityList;
        }

        public PostEntity RetrievePost(int postId)
        {
            PostEntity postEntityUI = new PostEntity();
            PB_POST postEntityEF = new PB_POST();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    postEntityEF = context.PB_POST.Single(x => x.ID == postId);
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
