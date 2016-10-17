using PastebookBusinessLogic.BusinessLogic;
using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Mappers;
using PastebookWebApplication.Models;

namespace PastebookWebApplication.Managers
{
    public class PasteBookManager
    {
        LogInManager logInManager = new LogInManager();

        public int CreateUser(LogInModel userModel)
        {
            LogInEntity userEntity = new LogInEntity();

            userEntity = UserMapper.MapUserModelToUserEntity(userModel);

            int result = logInManager.CreateUser(userEntity);

            return result;
        }

        public LogInModel RetrieveUser(string username)
        {
            LogInModel userModel = new LogInModel();
            LogInEntity userEntity = new LogInEntity();

            userEntity = logInManager.RetrieveUser(username);

            userModel = UserMapper.MapUserEntityToUserModel(userEntity);

            return userModel;
        }
    }
}