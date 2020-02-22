using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Status : BaseEntity
    {
        public string Name { get; set; }
    }
}
