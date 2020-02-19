using CoreData.Common.Entities.Notifications;
using Framework.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class User:BaseEntity
    {
        [Column(Order = 2)]
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public bool IsActivated{ get; set; }
        public string VerifiedCode { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureFileId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<NotificationUsers> Notifications { get; set; }
        public virtual ICollection<UserNotificationType> UserNotificationTypes { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Bag> Bags { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
