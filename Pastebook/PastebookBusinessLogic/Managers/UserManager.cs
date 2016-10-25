using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class UserManager : Repository<PB_USER>
    {
        public int CreateUser(PB_USER userModel)
        {
            PasswordManager passwordManager = new PasswordManager();
            string salt = "";

            userModel.PASSWORD = passwordManager.GeneratePasswordHash(userModel.PASSWORD, out salt);
            userModel.SALT = salt;
            userModel.DATE_CREATED = DateTime.UtcNow;
            userModel.BIRTHDAY = userModel.BIRTHDAY.ToUniversalTime();

            int result = Add(userModel);

            return result;
        }

        public int UpdateUser(PB_USER userModel)
        {
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToUniversalTime();
            userModel.BIRTHDAY = userModel.BIRTHDAY.ToUniversalTime();

            int result = Edit(userModel);

            return result;
        }

        public PB_USER RetrieveUserByID(int userID)
        {
            PB_USER userModel = new PB_USER();

            userModel = RetrieveSpecific(x => x.ID == userID);

            userModel.BIRTHDAY = userModel.BIRTHDAY.ToLocalTime();
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToLocalTime();

            return userModel;
        }

        public PB_USER RetrieveUserByEmail(string email)
        {
            PB_USER userModel = new PB_USER();

            userModel = RetrieveSpecific(x => x.EMAIL_ADDRESS == email);

            userModel.BIRTHDAY = userModel.BIRTHDAY.ToLocalTime();
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToLocalTime();

            return userModel;
        }

        public List<PB_USER> SearchUsers(string name)
        {
            List<PB_USER> users = new List<PB_USER>();

            users = Retrieve(x => x.FIRST_NAME == name || x.LAST_NAME == name);

            foreach (var user in users)
            {
                user.BIRTHDAY = user.BIRTHDAY.ToLocalTime();
                users.Add(user);
            }

            return users;
        }

        public bool CheckPassword(string email, string password)
        {
            PB_USER user = new PB_USER();

            user = RetrieveSpecific(x => x.EMAIL_ADDRESS == email);

            PasswordManager passwordManager = new PasswordManager();

            bool result = passwordManager.IsPasswordMatch(password, user.SALT, user.PASSWORD);

            return result;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = Check(x => x.EMAIL_ADDRESS == emailAddress);

            return result;
        }

        public bool CheckUsername(string username)
        {
            bool result = Check(x => x.USER_NAME == username);

            return result;
        }

        public bool ConfirmPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }

            return false;
        }
    }
}