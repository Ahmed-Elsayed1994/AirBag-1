using Framework.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public decimal Weight { get; set; }
        public decimal Hieght { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public string description { get; set; }
        public string Link { get; set; }
        public string PhotosIds { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ItemCategoryId")]
        public virtual ItemCategory ItemCategory { get; set; }
        [ForeignKey("AirPortTakeOffId")]
        public virtual AirPort AirPortTakeOff { get; set; }
        [ForeignKey("ArrivalAirPortId")]
        public virtual AirPort ArrivalAirPort { get; set; }
    }
}
