using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Invitation : BaseEntity
    {
        public int UserId { get; set; }
        public int UserInviteToId { get; set; }
        public int PromoCodeId { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("UserInviteToId")]
        public virtual User UserInviteTo { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual PromoCode PromoCode { get; set; }
    }
}
