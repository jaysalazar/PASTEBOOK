using System;

namespace PastebookBusinessLogic.Entities
{
    public class CommentEntity
    {
        public int CommentId { get; set; }

        public int PostId { get; set; }

        public int PosterId { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
