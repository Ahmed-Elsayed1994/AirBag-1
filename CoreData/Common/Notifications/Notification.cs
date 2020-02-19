using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Common.Entities.Notifications
{
    public class Notification : BaseEntity
    {
        public int SenderId { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Link { get; set; }
        public int FlgType { get; set; }

        [ForeignKey("SenderId")]
        public virtual Users.Entities.User Sender { get; set; }

        public virtual ICollection<NotificationUsers>  Recievers { get; set; }
    }
}
