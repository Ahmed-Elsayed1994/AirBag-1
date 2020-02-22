using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;

namespace User.BAL.Services
{
    public class ItemService : BaseService<Item, ItemVm>, IItemService
    {
        public ItemService(IRepository<Item> repository , IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

      
    }
}
