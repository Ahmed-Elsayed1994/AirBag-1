using NotificationManagement.Models;
using NotificationManagement.Models.Enum;
using push;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPush;

namespace NotificationManagement.Services
{
    public class SendingNotificationService : ISendNotificationService
    {
        private readonly IPushNotificationService _pushNotificationService;
        private readonly INotificationService _notificationService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly INotificationManagementService _notificationManagementService;

        public SendingNotificationService(
            IPushNotificationService pushNotificationService,
            INotificationService notificationService,
            IEmailSenderService emailSenderService,
            INotificationManagementService notificationManagementService)
        {
            _pushNotificationService = pushNotificationService;
            _notificationService = notificationService;
            _emailSenderService = emailSenderService;
            _notificationManagementService = notificationManagementService;
        }

        public async Task SendMessage(NotificationModel notificationModel,
            VapidDetails vapidDetails, int sigInUserId, int? userId)
        {
            IList<int> emailRecievers = new List<int>();
            IList<int> pushNotificationRecievers = new List<int>();
            IList<string> userEmails = new List<string>();

            // get user ids that we send notification to them
            _notificationManagementService.GetRecievers(ref emailRecievers, ref pushNotificationRecievers, ref userEmails, notificationModel);

            if (emailRecievers.Count > 0)
            {
                // send email then save this notification to db by notification service
                await _emailSenderService.SendEmailAsync(notificationModel.Title, notificationModel.Message, userEmails);
                _notificationService.SaveNotification(notificationModel, sigInUserId, emailRecievers, (int)NotificationType.Email);
            }
            if (pushNotificationRecievers.Count > 0)
            {
                notificationModel.RecieversIds = pushNotificationRecievers;
                // notify by push notification then save to db
                await _pushNotificationService.Notify(notificationModel, vapidDetails, sigInUserId, userId);
                _notificationService.SaveNotification(notificationModel, sigInUserId, notificationModel.RecieversIds,
                     (int)NotificationType.PushNotification);
            }
        }
    }
}
