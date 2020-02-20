using Framework.Core;
using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class RequestVm : IVM
    {
        public int RequestTypeId { get; set; }
        public int ActionId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string PromoCode { get; set; }
        public int UserId { get; set; }
        public string RequestTypeName { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
    }
}
