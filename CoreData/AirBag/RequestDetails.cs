using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class RequestDetails : BaseEntity
    {
        public int ItemId { get; set; }
        public int ActionId { get; set; }
        public DateTime ActionDateTime { get; set; }
        public int RequestId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [ForeignKey("ActionId")]
        public virtual Action Action { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
    }
}
