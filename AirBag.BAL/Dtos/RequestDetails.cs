using Framework.Core;
using Framework.Core.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class RequestDetailsVm : IVM
    {
        public int ItemId { get; set; }
        public DateTime ActionDateTime { get; set; }
        public int RequestId { get; set; }
        public string Item { get; set; }
    }
}
