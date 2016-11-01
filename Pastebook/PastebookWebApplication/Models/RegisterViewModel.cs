using PastebookEntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class RegisterViewModel
    {
        public PB_USER User { get; set; }

        public List<REF_COUNTRY> Countries { get; set; }

        [Required]
        [DisplayName("Confirm")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Current")]
        public string CurrentPassword { get; set; }
    }
}