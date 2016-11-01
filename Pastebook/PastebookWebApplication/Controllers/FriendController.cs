using PastebookBusinessLogic.Managers;
using PastebookEntityFramework;
using PastebookWebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PastebookWebApplication.Controllers
{
    public class FriendController : Controller
    {
        public ActionResult Index()
        {
            if (Session["CurrentUserID"] != null)
            {
                List<FriendUserViewModel> modelList = new List<FriendUserViewModel>();

                PB_USER userModel = new PB_USER();
                UserManager userManager = new UserManager();

                List<PB_FRIEND> friends = new List<PB_FRIEND>();
                FriendManager friendManager = new FriendManager();

                int userID = (int)Session["CurrentUserID"];

                friends = friendManager.RetrieveFriends(userID).ToList();

                if (friends.Count > 0)
                {
                    foreach (var friend in friends.Where(x => x.USER_ID == userID))
                    {
                        userModel = userManager.RetrieveUserByID(friend.FRIEND_ID);

                        modelList.Add(new FriendUserViewModel
                        {
                            Friend = friend,
                            User = userModel
                        });
                    }

                    foreach (var friend in friends.Where(x => x.FRIEND_ID == userID))
                    {
                        userModel = userManager.RetrieveUserByID(friend.USER_ID);

                        modelList.Add(new FriendUserViewModel
                        {
                            Friend = friend,
                            User = userModel
                        });
                    }
                }

                return View("Friends", modelList);
            }
            return RedirectToAction("LogIn", "Account");
        }
    }
}