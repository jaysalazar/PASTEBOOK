using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Models
{
    public class PostModel
    {
        public int PostID { get; set; }
        public string PosterUsername { get; set; }
        public byte[] PosterProfilePicture { get; set; }
        public string PosterFirstName { get; set; }
        public string PosterLastName { get; set; }
        public int ProfileOwnerID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}