using PastebookEntityFramework;

namespace PastebookWebApplication.Models
{
    public class PostViewModel
    {
        public PB_USER User { get; set; }
        public PB_POST Post { get; set; }
    }
}