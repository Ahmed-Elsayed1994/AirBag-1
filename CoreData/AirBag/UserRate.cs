using Framework.Core;

namespace CoreData.Users.Entities
{
    public class UserRate : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Rate Rate { get; set; }
    }
}
