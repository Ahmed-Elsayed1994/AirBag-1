using Framework.Core.Model;
using System;

namespace CoreData.Users.Entities
{
    public class ItemVm : IVM
    {
        public string Name { get; set; }
        public  int? ItemCategoryId { get; set; };
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public bool Boost { get; set; }
        public DateTime DateTimeTakeOff { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Weight { get; set; }
        public decimal Hieght { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public string Dscription { get; set; }
        public string Link { get; set; }
        public string PhotosIds { get; set; }
        public int UserId { get; set; }
    }

    public class ItemPartial: ItemVm
    {
        public string UserName { get; set; }
        public string ItemCategoryName { get; set; }
        public string AirPortTakeOffName { get; set; }
        public string ArrivalAirPortName { get; set; }
        public bool IsActive { get; set; }
        public int? ManagementApprovedStatusId { get; set; }
        public int? RequestApprovedStatusId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
