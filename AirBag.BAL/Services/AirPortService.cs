using System.Collections.Generic;
using System.Linq;
using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Framework.Helpers;

namespace User.BAL.Services
{
    public class AirPortService : BaseService<AirPort, AirPortVm>, IAirPortService
    {
        
        public AirPortService(IRepository<AirPort> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {

        }
        public override AirPortVm MapEntityToModel(AirPort entity)
        {
            return _mapper.Map<AirPortPartial>(entity);
        }

        public override IList<SelectListItem> GetRequiredCreateModel()
        {
            var item = new List<SelectListItem>();
            item.Add(new SelectListItem()
            {
                Key = "Cities",
                Values = _unitOfWork.City.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });
            return item;
        }


    }
}
