using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Framework.Helpers;
using System;

namespace User.BAL.Services
{
    public class BagService : BaseService<Bag, BagVm>, IBagService
    {
        public BagService(IRepository<Bag> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {
        }

        public override BagVm MapEntityToModel(Bag entity)
        {
            return _mapper.Map<BagPartial>(entity);
        }
        public override Bag MapModelToEntity(BagVm model)
        {
            if (model.Id == 0)
            {
                var newBagEntity = _mapper.Map<Bag>(model);
                newBagEntity.CreatedDateTime = DateTime.UtcNow;
                return newBagEntity;
            }
            var entity = _repository.GetById(model.Id);
            var returnEntity = _mapper.Map(model, entity);
            returnEntity.LastUpdatedDate = DateTime.UtcNow;
            return returnEntity;
        }


    }
}
