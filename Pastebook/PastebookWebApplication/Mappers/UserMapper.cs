using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Models;

namespace PastebookWebApplication.Mappers
{
    public static class UserMapper
    {
        //modelMVC as modelUI
        public static UserEntity MapUserModelToUserEntity(UserModel userModel)
        {
            UserEntity userEntity = new UserEntity()
            {
                Username = userModel.Username,
                Salt = userModel.Salt,
                PasswordHash = userModel.PasswordHash
            };

            return userEntity;
        }

        //modelUI as modelMVC
        public static UserModel MapUserEntityToUserModel(UserEntity userEntity)
        {
            UserModel userModel = new UserModel()
            {
                Username = userEntity.Username,
                Salt = userEntity.Salt,
                PasswordHash = userEntity.PasswordHash
            };

            return userModel;
        }
    }
}