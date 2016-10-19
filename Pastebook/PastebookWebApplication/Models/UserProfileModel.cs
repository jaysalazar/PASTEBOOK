using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Models
{
    public class UserProfileModel
    {
        public UserModel User { get; set; }

        public PostModel Post { get; set; }
    }
}