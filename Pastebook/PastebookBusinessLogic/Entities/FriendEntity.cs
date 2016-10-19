using System;

namespace PastebookBusinessLogic.Entities
{
    public class FriendEntity
    {
        public int PKFriendId { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public char Request { get; set; }

        public char Blocked { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
