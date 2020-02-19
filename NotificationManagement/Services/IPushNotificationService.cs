using CoreData.Common.Entities.Notifications;
using Framework.Core.UOW;
using NotificationManagement.Models;
using push;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPush;

namespace NotificationManagement.Services
{
    public interface IPushNotificationService
    {
        Task Notify(NotificationModel message, VapidDetails vapidDetails,int signInUserId, int? userId);
    }
}
