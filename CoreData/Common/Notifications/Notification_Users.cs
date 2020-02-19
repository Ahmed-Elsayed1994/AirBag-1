using Framework.Core;

namespace CoreData.Common.Entities.Notifications
{
    public class NotificationUsers : BaseEntity
    {
        public virtual Notification Notification { get; set; }
        public virtual Users.Entities.User Reciever { get; set; }
    }
}
