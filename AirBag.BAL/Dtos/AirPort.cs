using Framework.Core.Model;

namespace CoreData.Users.Entities
{
    public class AirPortVm : IVM
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }

    public class AirPortPartial : AirPortVm
    {
        public string CityName { get; set; }
    }
}
