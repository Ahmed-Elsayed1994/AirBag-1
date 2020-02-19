using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreData.Common.Entities.Notifications
{
    public class Subscriptions : BaseEntity
    {
        public string Endpoint { get; set; }
        public string P256DH { get; set; }
        public string Auth { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users.Entities.User User { get; set; }

    }
}
