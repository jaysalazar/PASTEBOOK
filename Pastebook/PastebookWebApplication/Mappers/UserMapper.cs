using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Models;

namespace PastebookWebApplication.Mappers
{
    public static class UserMapper
    {
        //modelMVC as modelUI
        public static LogInEntity MapUserModelToUserEntity(LogInModel userModel)
        {
            LogInEntity userEntity = new LogInEntity()
            {
                Username = userModel.Username,
                Salt = userModel.Salt,
                PasswordHash = userModel.PasswordHash
            };

            return userEntity;
        }

        //modelUI as modelMVC
        public static LogInModel MapUserEntityToUserModel(LogInEntity userEntity)
        {
            LogInModel userModel = new LogInModel()
            {
                Username = userEntity.Username,
                Salt = userEntity.Salt,
                PasswordHash = userEntity.PasswordHash
            };

            return userModel;
        }
    }
}