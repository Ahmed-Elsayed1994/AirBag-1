using CoreData.Common.Entities.Notifications;
using Framework.Core.UOW;
using NotificationManagement.Models;
using push;
using System.Collections.Generic;

namespace NotificationManagement.Services
{
    public interface INotificationManagementService : IBaseService<Subscriptions, SubscriptionVm>
    {
        void SubscribeUser(SubscriptionVm subscription);
        void UnSubscribe(SubscriptionVm subscription);
        IList<SubscriptionVm> GetSubscriptions(IList<int> userIds);
        void GetRecievers(ref IList<int> emailRecievers,
            ref IList<int> pushNotificationRecievers, ref IList<string> userEmails, NotificationModel notificationModel);


    }
}
