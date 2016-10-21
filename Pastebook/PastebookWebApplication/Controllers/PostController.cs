using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class PostController : Controller
    {
        // site/Posts/postID
        public ActionResult Index(int postID)
        {
            if (Session["CurrentUser"] != null)
            {
                return View();
            }

            return RedirectToAction("LogIn", "Account");
        }
    }
}