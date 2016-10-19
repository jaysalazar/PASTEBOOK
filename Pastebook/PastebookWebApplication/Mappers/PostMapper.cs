using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Mappers
{
    public class PostMapper
    {
        public static PostEntity MapPostModelToPostEntity(PostModel postModel)
        {
            PostEntity postEntity = new PostEntity()
            {
                PostId = postModel.PostId,
                PosterId = postModel.PosterId,
                ProfileOwnerId = postModel.ProfileOwnerId,
                Content = postModel.Content,
                CreatedDate = postModel.CreatedDate
            };

            return postEntity;
        }
        
        public static PostModel MapPostEntityToPostModel(PostEntity postEntity)
        {
            PostModel postModel = new PostModel()
            {
                PostId = postEntity.PostId,
                PosterId = postEntity.PosterId,
                ProfileOwnerId = postEntity.ProfileOwnerId,
                Content = postEntity.Content,
                CreatedDate = postEntity.CreatedDate
            };

            return postModel;
        }
    }
}