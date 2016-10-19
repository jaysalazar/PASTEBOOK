using PastebookBusinessLogic.BusinessLogic;
using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Mappers;
using PastebookWebApplication.Models;
using System.Collections.Generic;

namespace PastebookWebApplication.Managers
{
    public class ProfileManager
    {
        PostManager postManager = new PostManager();

        public int CreatePost(PostModel postModel)
        {
            PostEntity postEntity = new PostEntity();

            postEntity = PostMapper.MapPostModelToPostEntity(postModel);

            int result = postManager.CreatePost(postEntity);

            return result;
        }

        public List<PostModel> RetrieveAllPosts()
        {
            List<PostEntity> postList = new List<PostEntity>();
            PostModel postModel = new PostModel();
            List<PostModel> Posts = new List<PostModel>();

            postList = postManager.RetrieveAllPosts();

            foreach (var post in postList)
            {
                postModel = PostMapper.MapPostEntityToPostModel(post);
                Posts.Add(postModel);
            }

            return Posts;
        }

        public PostModel RetrievePost(int postId)
        {
            PostModel postModel = new PostModel();
            //do something
            return postModel;
        }
    }
}