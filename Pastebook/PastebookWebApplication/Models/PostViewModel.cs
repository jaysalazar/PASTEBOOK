using PastebookEntityFramework;
using System.Collections.Generic;

namespace PastebookWebApplication.Models
{
    public class PostViewModel
    {
        public PB_USER User { get; set; }

        public PB_POST Post { get; set; }

        //public List<PB_COMMENT> Comments { get; set; }

        //public List<PB_LIKE> Likes { get; set; }
    }
}