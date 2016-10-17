using System;

namespace PastebookBusinessLogic.Entities
{
    public class UserEntity
    {        
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string ConfirmPasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public DateTime Birthday { get; set; }

        public string Country { get; set; }

        public string MobileNumber { get; set; }
    }
}
