using Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Users.Entities
{
    public class UserRole : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
