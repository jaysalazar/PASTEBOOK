using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Models
{
    public class RegistrationModel : LogInModel
    {
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