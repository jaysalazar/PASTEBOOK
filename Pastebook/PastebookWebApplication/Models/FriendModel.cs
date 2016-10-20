using System;

namespace PastebookWebApplication.Models
{
    public class FriendModel
    {
        public int PKFriendId { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public string Request { get; set; }

        public string Blocked { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}