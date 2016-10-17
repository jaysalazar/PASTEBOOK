using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookDBEntities;
using PastebookWebApplication.Mappers;

namespace PastebookWebApplication.Managers
{
    public class LogInManager
    {
        PasswordManager passwordManager = new PasswordManager();
        List<Exception> exceptionList;

        public int CreateUser(LogInModel userModel)
        {
            int result = 0;
            PB_USER userEntity = new PB_USER();

            userEntity = UserMapper.MapUserModelToUserEntity(userModel);

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.PB_USER.Add(userEntity);
                    result = context.SaveChanges();
                }
                catch(Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public LogInModel RetrieveUser(string username)
        {
            LogInModel userModel = new LogInModel();

            PB_USER userEntity = new PB_USER();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    userEntity = context.PB_USER.Single(u => u.USER_NAME == username);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            userModel = UserMapper.MapUserEntityToUserModel(userEntity);

            return userModel;
        }
    }
}