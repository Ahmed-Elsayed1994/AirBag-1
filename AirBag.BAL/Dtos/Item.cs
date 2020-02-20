using Framework.Core.Model;

namespace CoreData.Users.Entities
{
    public class ItemVm : IVM
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
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ItemCategoryName { get; set; }
        public  string AirPortTakeOffName { get; set; }
        public string  ArrivalAirPortName { get; set; }
    }
}
