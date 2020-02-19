using Framework.Core;

namespace CoreData.Common.Entities.Notifications
{
    public class UserNotificationType : BaseEntity
    {
        public virtual Users.Entities.User User { get; set; }
        public int FlgNotificationType{ get; set; }
    }
}
