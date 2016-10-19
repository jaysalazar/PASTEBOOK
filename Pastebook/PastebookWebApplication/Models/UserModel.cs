using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Password")]
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        [Compare("PasswordHash", ErrorMessage = "{0} does not match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public DateTime Birthday { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public List<CountryModel> Countries { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
    }
}