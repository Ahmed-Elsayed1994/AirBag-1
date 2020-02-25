using CoreData.Common.Entities.Notifications;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class User : BaseEntity
    {
        [Column(Order = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public bool IsActivated { get; set; } = false;
        public string VerifiedCode { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureFileId { get; set; }
        public string  CoverPictureFileId { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDateTime{ get; set; }
        public bool? RemeberMe { get; set; } = false;
        public int? CountryId{ get; set; }
        public int? NationalityId { get; set; }
        public bool SenderMore { get; set; } = false;
        public bool CarrierMore { get; set; } = false;

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Rate { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<NotificationUsers> Notifications { get; set; }
        public virtual ICollection<UserNotificationType> UserNotificationTypes { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Bag> Bags { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ManagementNotes> ManagementNotes { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Rate> MyRates { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Invitation> MyInvitations { get; set; }
        public virtual ICollection<Item> ApprovedItems { get; set; }
        public virtual ICollection<Bag> ApprovedBags { get; set; }
    }
}
