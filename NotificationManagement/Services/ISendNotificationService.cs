using push;
using System.Threading.Tasks;
using WebPush;

namespace NotificationManagement.Models
{
    public interface ISendNotificationService
    {
        Task SendMessage(NotificationModel notificationModel,
            VapidDetails vapidDetails, int sigInUserId, int? userId);
    }
}
