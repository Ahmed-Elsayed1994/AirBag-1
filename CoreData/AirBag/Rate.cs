using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Rate: BaseEntity
    {
        public int UserRateToId { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("UserRateToId")]
        public virtual User UserRateTo { get; set; }
        public virtual ICollection<UserRate> UserRates { get; set; }
    }
}
