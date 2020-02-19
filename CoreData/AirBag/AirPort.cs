using Framework.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class AirPort : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
