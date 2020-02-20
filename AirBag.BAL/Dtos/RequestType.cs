using Framework.Core;
using Framework.Core.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class RequestTypeVm : IVM
    {
        public string Name { get; set; }
    }
}
