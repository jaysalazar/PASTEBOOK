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
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "{0} does not match.")]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Country_ID { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
    }
}