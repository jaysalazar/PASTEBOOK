using System;

namespace PastebookBusinessLogic.Entities
{
    public class NotificationEntity
    {
        public int NotificationId { get; set; }

        public int ReceiverId { get; set; }

        public int SenderId { get; set; }

        public DateTime CreatedDate { get; set; }

        public char NotificationType { get; set; }

        public int CommentId { get; set; }

        public int PostId { get; set; }

        public char Seen { get; set; }
    }
}
