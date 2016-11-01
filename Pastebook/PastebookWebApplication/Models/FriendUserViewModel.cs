using PastebookEntityFramework;

namespace PastebookWebApplication.Models
{
    public class FriendUserViewModel
    {
        public PB_USER User { get; set; }

        public PB_FRIEND Friend { get; set; }
    }
}