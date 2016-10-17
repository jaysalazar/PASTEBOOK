using PastebookBusinessLogic.Entities;
using PastebookBusinessLogic.Mappers;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class LogInManager
    {
        PasswordManager passwordManager = new PasswordManager();
        List<Exception> exceptionList;

        public int CreateUser(UserEntity userEntityUI)
        {
            int result = 0;
            PB_USER userEntityEF = new PB_USER();

            userEntityEF = UserMapper.MapUserEntityUIToUserEntityEF(userEntityUI);

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.PB_USER.Add(userEntityEF);
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

        public UserEntity RetrieveUser(string username)
        {
            UserEntity userEntityUI = new UserEntity();

            PB_USER userEntityEF = new PB_USER();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    userEntityEF = context.PB_USER.Single(u => u.USER_NAME == username);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            userEntityUI = UserMapper.MapUserEntityEFToUserEntityUI(userEntityEF);

            return userEntityUI;
        }
    }
}