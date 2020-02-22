using Framework.Core;
using Framework.Core.Model;

namespace CoreData.Users.Entities
{

    public class MobileCountryCodeVm : IVM
    {
        public string CountryCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
