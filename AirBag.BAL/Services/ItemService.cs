using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using System;

namespace User.BAL.Services
{
    public class ItemService : BaseService<Item, ItemVm>, IItemService
    {
        public ItemService(IRepository<Item> repository , IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }
        public override ItemVm MapEntityToModel(Item entity)
        {
            return _mapper.Map<ItemPartial>(entity);
        }
        public override Item MapModelToEntity(ItemVm model)
        {
            if (model.Id == 0)
            {
                var newBagEntity = _mapper.Map<Item>(model);
                newBagEntity.CreatedDate = DateTime.UtcNow;
                return newBagEntity;
            }
            var entity = _repository.GetById(model.Id);
            var returnEntity = _mapper.Map(model, entity);
            returnEntity.LastUpdatedDate = DateTime.UtcNow;
            return returnEntity;
        }


    }
}
