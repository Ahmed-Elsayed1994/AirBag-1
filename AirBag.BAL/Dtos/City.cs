using Framework.Core;
using Framework.Core.Model;

namespace CoreData.Users.Entities
{
    public class CityVm : IVM
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
