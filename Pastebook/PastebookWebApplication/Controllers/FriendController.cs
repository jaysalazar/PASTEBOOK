using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class FriendController : Controller
    {
        // site/friends
        [ActionName("friends")]
        public ActionResult Index()
        {
            return View();
        }
    }
}