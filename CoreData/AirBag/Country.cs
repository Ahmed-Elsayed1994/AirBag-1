using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
