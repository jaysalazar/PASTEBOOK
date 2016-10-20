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
        FriendManager friendManager = new FriendManager();

        public int CreatePost(PostModel postModel)
        {
            PostEntity postEntity = new PostEntity();

            postEntity = PostMapper.MapPostModelToPostEntity(postModel);

            int result = postManager.CreatePost(postEntity);

            return result;
        }

        public List<PostModel> RetrieveAllPosts(FriendModel friendModel)
        {
            List<PostEntity> postList = new List<PostEntity>();
            PostModel postModel = new PostModel();
            List<PostModel> Posts = new List<PostModel>();
            FriendEntity friendEntity = new FriendEntity();

            friendEntity = FriendMapper.MapFriendModelToFriendEntity(friendModel);
            postList = postManager.RetrieveAllPosts(friendEntity);

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
            PostEntity postEntity = new PostEntity();

            postEntity = postManager.RetrievePost(postId);
            postModel = PostMapper.MapPostEntityToPostModel(postEntity);

            return postModel;
        }

        public int AddFriend(FriendModel friendModel)
        {
            FriendEntity friendEntity = new FriendEntity();

            friendEntity = FriendMapper.MapFriendModelToFriendEntity(friendModel);

            int result = friendManager.AddFriend(friendEntity);

            return result;
        }

        public List<FriendModel> RetrieveAllFriends(int userId)
        {
            List<FriendEntity> friendList = new List<FriendEntity>();
            FriendModel friendModel = new FriendModel();
            List<FriendModel> Friends = new List<FriendModel>();
            FriendEntity friendEntity = new FriendEntity();

            friendEntity = FriendMapper.MapFriendModelToFriendEntity(friendModel);
            friendList = friendManager.RetrieveAllFriends(userId);

            foreach (var friend in friendList)
            {
                friendModel = FriendMapper.MapFriendEntityToFriendModel(friend);
                Friends.Add(friendModel);
            }

            return Friends;
        }
    }
}