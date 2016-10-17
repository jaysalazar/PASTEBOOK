using PastebookBusinessLogic.BusinessLogic;
using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Mappers;
using PastebookWebApplication.Models;

namespace PastebookWebApplication.Managers
{
    public class PasteBookManager
    {
        LogInManager logInManager = new LogInManager();

        public int CreateUser(UserModel userModel)
        {
            UserEntity userEntity = new UserEntity();

            userEntity = UserMapper.MapUserModelToUserEntity(userModel);

            int result = logInManager.CreateUser(userEntity);

            return result;
        }

        public UserModel RetrieveUser(string username)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = new UserEntity();

            userEntity = logInManager.RetrieveUser(username);

            userModel = UserMapper.MapUserEntityToUserModel(userEntity);

            return userModel;
        }
    }
}