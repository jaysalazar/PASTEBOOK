using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class ActionManager
    {
        List<Exception> exceptionList;

        public int AddLike(LikeEntity likeEntityUI)
        {
            int result = 0;
            PB_LIKE postEntityEF = new PB_LIKE();

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

        public List<PostEntity> RetrieveAllPosts(FriendEntity friendEntity)
        {
            List<PostEntity> postEntityList = new List<PostEntity>();
            PostEntity postEntity = new PostEntity();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    // timeline = current user profile_owner_id
                    // newsfeed = timeline || (friend poster_Id && user poster_Id)
                    var result = context.PB_POST.Where(x => x.PROFILE_OWNER_ID == friendEntity.UserId ||
                                                      (x.POSTER_ID == friendEntity.FriendId &&
                                                       x.POSTER_ID == friendEntity.UserId))
                                                .OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();

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
