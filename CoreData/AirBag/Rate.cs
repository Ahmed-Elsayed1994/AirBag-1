using Framework.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Rate: BaseEntity
    {
        public int UserId { get; set; }
        public int UserRateToId { get; set; }
        public string Comment { get; set; }
        public decimal Value { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("UserRateToId")]
        public virtual User UserRateTo { get; set; }
    }
}
