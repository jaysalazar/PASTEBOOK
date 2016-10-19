using PastebookBusinessLogic.Entities;
using PastebookBusinessLogic.Mappers;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class UserManager
    {
        List<Exception> exceptionList;

        public int CreateUser(UserEntity userEntityUI)
        {
            int result = 0;
            PB_USER userEntityEF = new PB_USER();

            userEntityEF = UserMapper.MapUserEntityUIToUserEntityEF(userEntityUI);
            userEntityEF.DATE_CREATED = DateTime.UtcNow;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.PB_USER.Add(userEntityEF);
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public UserEntity RetrieveUser(string emailAddress)
        {
            UserEntity userEntityUI = new UserEntity();
            PB_USER userEntityEF = new PB_USER();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    userEntityEF = context.PB_USER.Single(x => x.EMAIL_ADDRESS == emailAddress);
                    userEntityUI = UserMapper.MapUserEntityEFToUserEntityUI(userEntityEF);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return userEntityUI;
        }

        public bool CheckPassword(string password, string salt, string hash)
        {
            bool result = false;
            PasswordManager passwordManager = new PasswordManager();

            try
            {
                result = passwordManager.IsPasswordMatch(password, salt, hash);
            }
            catch (Exception ex)
            {
                exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = false;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.PB_USER.Any(x => x.EMAIL_ADDRESS == emailAddress);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public bool CheckUsername(string username)
        {
            bool result = false;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.PB_USER.Any(x => x.USER_NAME == username);
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }
    }
}