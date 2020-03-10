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
    public class CityService : BaseService<City, CityVm>, ICityService
    {
        public CityService(IRepository<City> repository , IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

        public override IList<SelectListItem> GetRequiredCreateModel()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Key = "Countries",
                Values = _unitOfWork.Country.GetAll().Select(a => new RequiredItems()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            });
            return items;
        }
    }
}
