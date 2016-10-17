using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Managers
{
    //insert src here
    public class PasswordManager
    {
        HashComputer hashComputer = new HashComputer();

        public string GeneratePasswordHash(string password, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = password + salt;

            return hashComputer.GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;

            return hash == hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }
}