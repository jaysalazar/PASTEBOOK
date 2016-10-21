using PastebookEntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class PastebookModel
    {
        public LogInModel User { get; set; }

        public PB_USER UserEntity { get; set; }
        public PB_POST PostEntity { get; set; }
        
    }
}