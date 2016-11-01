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

            return Add(userModel);
        }

        public int UpdateUser(PB_USER userModel)
        {
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToUniversalTime();

            return Edit(userModel);
        }

        public PB_USER RetrieveUserByID(int userID)
        {
            PB_USER userModel = new PB_USER();

            userModel = RetrieveSpecific(x => x.ID == userID);
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToLocalTime();

            return userModel;
        }

        public PB_USER RetrieveUserByEmail(string email)
        {
            PB_USER userModel = new PB_USER();

            userModel = RetrieveSpecific(x => x.EMAIL_ADDRESS == email);
            userModel.DATE_CREATED = userModel.DATE_CREATED.ToLocalTime();

            return userModel;
        }

        public List<PB_USER> SearchUsers(string name)
        {
            List<PB_USER> users = new List<PB_USER>();

            var result = Retrieve(x => x.FIRST_NAME == name || x.LAST_NAME == name);

            foreach (var user in result)
            {
                user.DATE_CREATED = user.DATE_CREATED.ToLocalTime();
                users.Add(user);
            }

            return users;
        }

        public bool CheckEmailAddress(string email)
        {
            return Check(x => x.EMAIL_ADDRESS == email);
        }

        public bool CheckUsername(string username)
        {
            return Check(x => x.USER_NAME == username);
        }

        public bool CheckPassword(string email, string password)
        {
            PB_USER userModel = new PB_USER();
            PasswordManager passwordManager = new PasswordManager();

            if (CheckEmailAddress(email) == true)
            {
                userModel = RetrieveSpecific(x => x.EMAIL_ADDRESS == email);
                return passwordManager.IsPasswordMatch(password, userModel.SALT, userModel.PASSWORD);
            }

            return false;
        }
    }
}