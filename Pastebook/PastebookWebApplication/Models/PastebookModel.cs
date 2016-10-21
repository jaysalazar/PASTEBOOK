using PastebookDataAccess;
using System.Collections.Generic;

namespace PastebookWebApplication.Models
{
    public class PastebookModel
    {
        public PB_USER User { get; set; }

        public string ConfirmPassword { get; set; }

        public PB_POST Post { get; set; }
        
    }
}