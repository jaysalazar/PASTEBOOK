using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "{0} field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        [Compare("PasswordHash", ErrorMessage = "{0} does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        public DateTime Birthday { get; set; }

        public int CountryId { get; set; }

        public List<CountryModel> Countries { get; set; }

        public string MobileNumber { get; set; }
    }
}