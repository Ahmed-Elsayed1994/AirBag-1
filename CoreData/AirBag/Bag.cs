using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class Bag : BaseEntity
    {
        public string Name { get; set; }
        public int AirPortCompanyId { get; set; }
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public DateTime DateTimeTakeOff { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string TripNumber { get; set; }
        public decimal AvailableWeight { get; set; }
        public decimal Weight { get; set; }
        public decimal CostPerKG { get; set; }
        public string TiketPhotoId { get; set; }
        public bool Boost { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("AirPortTakeOffId")]
        public virtual AirPort AirPortTakeOff { get; set; }
        [ForeignKey("ArrivalAirPortId")]
        public virtual AirPort ArrivalAirPort { get; set; }
        [ForeignKey("AirPortCompanyId")]
        public virtual AirPortCaompany AirPortCaompany { get; set; }
        public virtual ICollection<UnWantedBagCategory> UnWantedBagCategories { get; set; }
    }
}
