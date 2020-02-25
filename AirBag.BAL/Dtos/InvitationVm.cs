using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class InvitationVm : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public int UserInviteToId { get; set; }
        public int PromoCodeId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserInviteToName { get; set; }
        public string PromoCodeCode { get; set; }
    }
}
