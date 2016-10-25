using PastebookEntityFramework;
using System.Collections.Generic;
using System.ComponentModel;

namespace PastebookWebApplication.Models
{
    public class RegisterViewModel
    {
        public PB_USER User { get; set; }

        public List<REF_COUNTRY> Countries { get; set; }

        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}