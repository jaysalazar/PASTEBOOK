using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class PostController : Controller
    {
        [Route("posts/{postID}")]
        public ActionResult Post(int postID)
        {
            if (Session["CurrentUserID"] != null)
            {
                PostManager postManager = new PostManager();

                PB_POST postModel = new PB_POST();

                postModel = postManager.RetrievePost(postID);

                return View(postModel);
            }

            return RedirectToAction("LogIn", "Account");
        }
    }
}