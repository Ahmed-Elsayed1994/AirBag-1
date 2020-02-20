using Framework.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Rate: BaseEntity
    {
        public int UserRateToId { get; set; }
        public string Comment { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Value { get; set; }
        [ForeignKey("UserRateToId")]
        public virtual User UserRateTo { get; set; }
        public virtual ICollection<UserRate> UserRates { get; set; }
    }
}
