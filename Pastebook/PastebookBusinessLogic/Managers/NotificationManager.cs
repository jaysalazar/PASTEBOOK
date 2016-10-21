using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBusinessLogic.Managers
{
    public class NotificationManager : Repository<PASTEBOOK_DBEntities, PB_NOTIFICATION>
    {
        public int AddNotification(PB_NOTIFICATION notificationEntity)
        {
            int result = 0;

            try
            {
                result = Add(notificationEntity);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return result;
        }

        public List<PB_NOTIFICATION> RetrieveNotifications(int userId)
        {
            List<PB_NOTIFICATION> notifications = new List<PB_NOTIFICATION>();

            try
            {
                var result = Retrieve(x => x.RECEIVER_ID == userId);

                foreach (var notification in result)
                {
                    notifications.Add(notification);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return notifications;
        }
    }
}
