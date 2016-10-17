using System;

namespace PastebookWebApplication.Models
{
    public class UserModel
    {
        //[Required]
        public string Username { get; set; }
        //[Required]
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string ConfirmPasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //create list
        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public DateTime Birthday { get; set; }

        //country json
        public string Country { get; set; }

        public string MobileNumber { get; set; }
    }
}