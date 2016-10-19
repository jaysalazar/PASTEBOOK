using System;

namespace PastebookWebApplication.Models
{
    public class PostModel
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ProfileOwnerId { get; set; }

        public int PosterId { get; set; }
    }
}