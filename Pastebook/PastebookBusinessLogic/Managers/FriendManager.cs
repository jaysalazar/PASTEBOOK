using PastebookDataAccess;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class FriendManager : Repository<PASTEBOOK_DBEntities, PB_FRIEND>
    {
        public int AddFriend(PB_FRIEND friendEntity)
        {
            int result = 0;

            friendEntity.CREATED_DATE = DateTime.UtcNow;

            try
            {
                result = Add(friendEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }
        
        public List<PB_FRIEND> RetrieveAllFriends(int userId)
        {
            List<PB_FRIEND> friends = new List<PB_FRIEND>();

            try
            {
                var result = Retrieve(x => x.USER_ID == userId);

                foreach (var friend in result)
                {
                    friend.CREATED_DATE = friend.CREATED_DATE.ToLocalTime();
                    friends.Add(friend);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return friends;
        }
    }
}