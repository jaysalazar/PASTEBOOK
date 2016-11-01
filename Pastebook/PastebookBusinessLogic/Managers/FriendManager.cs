using PastebookDataAccess;
using PastebookEntityFramework;
using System;
using System.Collections.Generic;

namespace PastebookBusinessLogic.Managers
{
    public class FriendManager : Repository<PB_FRIEND>
    {
        public int AddFriendRequest(PB_FRIEND friendEntity)
        {
            friendEntity.CREATED_DATE = DateTime.UtcNow;
            friendEntity.REQUEST = "Y";
            friendEntity.BLOCKED = "N";
            return Add(friendEntity);
        }

        public int AddFriend(PB_FRIEND friendEntity)
        {
            if (friendEntity.REQUEST == "Y")
            {
                friendEntity.CREATED_DATE = DateTime.UtcNow;
                friendEntity.REQUEST = "N";
                return Add(friendEntity);
            }

            return 0;
        }

        public List<PB_FRIEND> RetrieveFriends(int userID)
        {
            List<PB_FRIEND> friends = new List<PB_FRIEND>();

            var result = Retrieve(x => x.REQUEST == "N" && (x.USER_ID == userID || x.FRIEND_ID == userID));

            foreach (var friend in result)
            {
                friend.CREATED_DATE = friend.CREATED_DATE.ToLocalTime();
                friends.Add(friend);
            }

            return friends;
        }
    }
}