using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class RegisterModel
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "{0}s do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        [DisplayName("Country")]
        public int Country_ID { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

    }
}