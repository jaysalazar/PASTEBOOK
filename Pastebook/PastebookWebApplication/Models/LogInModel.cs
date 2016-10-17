using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Models
{
    public class LogInModel
    {
        //[Required]
        public string Username { get; set; }
        //[Required]
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}