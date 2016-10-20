using System;

namespace PastebookBusinessLogic.Entities
{
    public class PostEntity
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ProfileOwnerId { get; set; }

        public int PosterId { get; set; }
    }
}
