using PastebookDBEntities;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Mappers
{
    public static class UserMapper
    {
        //modelMVC to modelEF
        public static PB_USER MapUserModelToUserEntity(LogInModel userModel)
        {
            PB_USER userEntity = new PB_USER()
            {
                USER_NAME = userModel.Username,
                SALT = userModel.Salt,
                PASSWORD = userModel.PasswordHash
            };

            return userEntity;
        }

        //modelEF to modelMVC
        public static LogInModel MapUserEntityToUserModel(PB_USER userEntity)
        {
            LogInModel userModel = new LogInModel()
            {
                Username = userEntity.USER_NAME,
                Salt = userEntity.SALT,
                PasswordHash = userEntity.PASSWORD
            };

            return userModel;
        }
    }
}