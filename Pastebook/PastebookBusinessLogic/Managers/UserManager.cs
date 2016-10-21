using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class UserManager : Repository<PASTEBOOK_DBEntities, PB_USER>
    {
        public int CreateUser(PB_USER userEntity)
        {
            int result = 0;
            
            userEntity.DATE_CREATED = DateTime.UtcNow;
            userEntity.BIRTHDAY = userEntity.BIRTHDAY.ToUniversalTime();

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

        public PB_USER RetrieveUser(string emailAddress)
        {
            PB_USER userEntity = new PB_USER();

            try
            {
                userEntity = Retrieve(x => x.EMAIL_ADDRESS == emailAddress).SingleOrDefault();
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