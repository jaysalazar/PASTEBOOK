using PastebookBusinessLogic.Entities;
using PastebookDataAccess;

namespace PastebookBusinessLogic.Mappers
{
    class PostMapper
    {
        public static PB_POST MapPostEntityUIToPostEntityEF(PostEntity postEntityUI)
        {
            PB_POST postEntityEF = new PB_POST()
            {
               ID = postEntityUI.PostId,
               POSTER_ID = postEntityUI.PosterId,
               PROFILE_OWNER_ID = postEntityUI.ProfileOwnerId,
               CONTENT = postEntityUI.Content,
               CREATED_DATE = postEntityUI.CreatedDate
            };

            return postEntityEF;
        }
        
        public static PostEntity MapPostEntityEFToPostEntityUI(PB_POST postEntityEF)
        {
            PostEntity postEntityUI = new PostEntity()
            {
                PostId = postEntityEF.ID,
                PosterId = postEntityEF.POSTER_ID,
                ProfileOwnerId = postEntityEF.PROFILE_OWNER_ID,
                Content = postEntityEF.CONTENT,
                CreatedDate = postEntityEF.CREATED_DATE
            };

            return postEntityUI;
        }
    }
}
