using System.Collections.Generic;

namespace PastebookWebApplication.Models
{
    public class UserProfileModel
    {
        public UserModel User { get; set; }

        public PostModel Post { get; set; }
    }
}