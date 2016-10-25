using PastebookEntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastebookWebApplication.Models
{
    public class UserPostViewModel
    {
        public PB_USER User { get; set; }
        public PB_POST Post { get; set; }
    }
}