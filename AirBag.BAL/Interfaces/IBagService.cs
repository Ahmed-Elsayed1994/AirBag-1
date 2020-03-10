using CoreData.Users.Entities;
using Framework.Core.UOW;
using System.Collections.Generic;

namespace AirBag.BAL.Interfaces
{
    public interface IBagService : IBaseService<Bag, BagVm>
    {
        IList<BagVm> MyBags(int userId);
    }
}
