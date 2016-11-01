using PastebookEntityFramework;

namespace PastebookWebApplication.Models
{
    public class ActionViewModel
    {
        public int PostID { get; set; }

        public PB_USER User { get; set; }

        public PB_LIKE Like { get; set; }

        public PB_COMMENT Comment { get; set; }
    }
}