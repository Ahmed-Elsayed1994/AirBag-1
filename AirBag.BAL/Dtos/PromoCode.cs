using Framework.Core.Model;
using System;

namespace CoreData.Users.Entities
{
    public class PromoCodeVm : IVM
    {
        public string Code { get; set; }
        public decimal DiscountCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
