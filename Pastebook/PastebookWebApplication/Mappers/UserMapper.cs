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
                PasswordHash = userModel.PasswordHash,
                ConfirmPassword = userModel.ConfirmPassword,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Gender = userModel.Gender,
                EmailAddress = userModel.EmailAddress,
                Birthday = userModel.Birthday,
                CountryId = userModel.CountryId,
                MobileNumber = userModel.MobileNumber
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
                PasswordHash = userEntity.PasswordHash,
                ConfirmPassword = userEntity.ConfirmPassword,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Gender = userEntity.Gender,
                EmailAddress = userEntity.EmailAddress,
                Birthday = userEntity.Birthday,
                CountryId = userEntity.CountryId,
                MobileNumber = userEntity.MobileNumber
            };

            return userModel;
        }
    }
}