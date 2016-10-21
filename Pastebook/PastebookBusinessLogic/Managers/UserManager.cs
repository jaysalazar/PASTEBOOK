using PastebookBusinessLogic.Managers;
using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class UserManager : Repository<PB_USER>
    {
        PasswordManager passwordManager = new PasswordManager();

        public int CreateUser(PB_USER userEntity)
        {
            int result = 0;
            string salt = "";

            userEntity.USER_NAME = userEntity.USER_NAME.Trim();
            userEntity.PASSWORD = userEntity.PASSWORD.Trim();
            userEntity.PASSWORD = passwordManager.GeneratePasswordHash(userEntity.PASSWORD, out salt);
            userEntity.SALT = salt;
            userEntity.FIRST_NAME = userEntity.FIRST_NAME.Trim();
            userEntity.LAST_NAME = userEntity.LAST_NAME.Trim();
            userEntity.MOBILE_NO = userEntity.MOBILE_NO.Trim();
            userEntity.DATE_CREATED = DateTime.UtcNow;
            userEntity.BIRTHDAY = userEntity.BIRTHDAY.ToUniversalTime();
            userEntity.EMAIL_ADDRESS = userEntity.EMAIL_ADDRESS.Trim();

            if (userEntity.ABOUT_ME != null)
            {
                userEntity.ABOUT_ME.Trim();
            }

            try
            {
                result = Add(userEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public PB_USER RetrieveUser(string username)
        {
            PB_USER userEntity = new PB_USER();

            try
            {
                userEntity = Retrieve(x => x.USER_NAME == username).SingleOrDefault();
                userEntity.BIRTHDAY = userEntity.BIRTHDAY.ToLocalTime();
                userEntity.DATE_CREATED = userEntity.DATE_CREATED.ToLocalTime();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return userEntity;
        }

        public PB_USER RetrieveUserByEmail(string email)
        {
            PB_USER userEntity = new PB_USER();

            try
            {
                userEntity = Retrieve(x => x.EMAIL_ADDRESS == email).SingleOrDefault();
                // try
                userEntity.BIRTHDAY.ToLocalTime();
                // userEntity.BIRTHDAY = userEntity.BIRTHDAY.ToLocalTime();
                userEntity.DATE_CREATED = userEntity.DATE_CREATED.ToLocalTime();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return userEntity;
        }

        public int UpdateUser(PB_USER userEntity)
        {
            int result = 0;

            userEntity.DATE_CREATED = userEntity.DATE_CREATED.ToUniversalTime();
            userEntity.BIRTHDAY = userEntity.BIRTHDAY.ToUniversalTime();

            try
            {
                result = Edit(userEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public List<PB_USER> SearchUsers(string name)
        {
            List<PB_USER> users = new List<PB_USER>();

            try
            {
                var result = Retrieve(x => x.FIRST_NAME == name || x.LAST_NAME == name);

                foreach (var user in result)
                {
                    user.BIRTHDAY = user.BIRTHDAY.ToLocalTime();
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return users;
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
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = false;

            try
            {
                result = Retrieve().Any(x => x.EMAIL_ADDRESS == emailAddress);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
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
                    result = Retrieve().Any(x => x.USER_NAME == username);
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }
    }
}