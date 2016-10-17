using System;

namespace PastebookBusinessLogic.Entities
{
    public class RegistrationEntity : LogInEntity
    {
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
