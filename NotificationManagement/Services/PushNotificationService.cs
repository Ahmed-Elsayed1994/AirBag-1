using Newtonsoft.Json;
using push;
using System.Threading.Tasks;
using WebPush;

namespace NotificationManagement.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly INotificationManagementService _notificationManagementService;
        public PushNotificationService(INotificationManagementService notificationManagementService)
        
        {
            _notificationManagementService = notificationManagementService;
        }

        public async Task Notify(NotificationModel notificationModel,
            VapidDetails vapidDetails, int sigInUserId, int? userId)
        {
            var subscriptions = _notificationManagementService.GetSubscriptions(notificationModel.RecieversIds);
            var serializedMessage = JsonConvert.SerializeObject(notificationModel);
            var client = new WebPushClient();
            foreach (var pushSubscription in subscriptions)
            {
                await client.SendNotificationAsync(new PushSubscription()
                {
                    Auth = pushSubscription.Auth,
                    Endpoint = pushSubscription.Endpoint,
                    P256DH = pushSubscription.P256DH
                }, serializedMessage, vapidDetails);
            }
        }
    }
}
