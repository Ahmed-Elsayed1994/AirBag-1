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
using System.Collections.Generic;
using System.Linq;

namespace User.BAL.Services
{
    public class BagService : BaseService<Bag, BagVm>, IBagService
    {
        public BagService(IRepository<Bag> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {
        }

        public override IPagedResult<Bag, IVM> GetPagedResult(QueryModel queryModel)
        {
            var q = _repository.Where(a => a.IsActive && !a.IsDeleted);
            return new PagedResult<Bag, IVM>(q.AsQueryable(), queryModel.CurrentPage, queryModel.PageSize, FuncToVM());
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

        public override IList<SelectListItem> GetRequiredCreateModel()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Key = "AirLines",
                Values = _unitOfWork.AirLine.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });
            items.Add(new SelectListItem()
            {
                Key = "AirPorts",
                Values = _unitOfWork.AirLine.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });
            return items;
        }

        public IList<BagVm> MyBags(int userId)
        {
            var bags = _repository.Where(a => a.UserId == userId);
            return MapentityListToModels(bags.ToList());
        }
    }
}
