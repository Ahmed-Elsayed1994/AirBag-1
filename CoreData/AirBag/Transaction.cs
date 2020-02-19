using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Cost { get; set; }
        public int UserCardId { get; set; }
        public DateTime DateTime { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("UserCardId")]
        public virtual Card Card { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
    }
}
