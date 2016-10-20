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

            try
            {
                result = Add(userEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public PB_USER RetrieveUser(string emailAddress)
        {
            PB_USER userEntity = new PB_USER();

            try
            {
                userEntity = Retrieve(x => x.EMAIL_ADDRESS == emailAddress).SingleOrDefault();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return userEntity;
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
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = false;

            try
            {
                result = Retrieve(x => x.EMAIL_ADDRESS == emailAddress).Any();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
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
                    result = Retrieve(x => x.USER_NAME == username).Any();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                    foreach (var exception in exceptionList)
                    {
                        throw new Exception(exception.Message, ex);
                    }
                }
            }

            return result;
        }
    }
}