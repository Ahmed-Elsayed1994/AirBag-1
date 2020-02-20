using Framework.Core;
using Framework.Core.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class RateVm: IVM
    {
        public int UserRateToId { get; set; }
        public string Comment { get; set; }
        public decimal Value { get; set; }
        public string UserRateToName { get; set; }
    }
}
