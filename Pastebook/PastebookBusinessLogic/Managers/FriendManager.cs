using PastebookBusinessLogic.Entities;
using PastebookBusinessLogic.Mappers;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class FriendManager
    {
        List<Exception> exceptionList;

        public int AddFriend(FriendEntity friendEntity)
        {
            int result = 0;
            PB_FRIEND friendEntityEF = new PB_FRIEND();

            friendEntityEF = FriendMapper.MapFriendEntityUIToFriendEntityEF(friendEntity);
            friendEntityEF.CREATED_DATE = DateTime.UtcNow;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.PB_FRIEND.Add(friendEntityEF);
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public List<FriendEntity> RetrieveAllFriends(int userId)
        {
            List<FriendEntity> friendEntityList = new List<FriendEntity>();
            FriendEntity friendEntity = new FriendEntity();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    var result = context.PB_FRIEND.Where(x => x.USER_ID == userId).ToList();

                    foreach (var friend in result)
                    {
                        friendEntity = FriendMapper.MapFriendEntityEFToFriendEntityUI(friend);
                        friendEntityList.Add(friendEntity);
                    }
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return friendEntityList;
        }
    }
}
