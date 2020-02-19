using CoreData.Common.Entities.Notifications;
using Framework.Core.UOW;
using NotificationManagement.Models;
using push;
using System.Collections.Generic;

namespace NotificationManagement.Services
{
    public interface INotificationService : IBusiness<Notification, NotificationVm>
    {
        HeaderNotificationVm GetNotificationsByUser(int userId);
        void MakeAsRead(int userId);
        void SaveNotification(NotificationModel notificationModel,
            int sigInUserId, IList<int> recieversIds, int flgType);
    }
}
