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
    public class NationalityService : BaseService<Nationality, NationalityVm>, INationalityService
    {
        public NationalityService(IRepository<Nationality> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {
        }

      
    }
}
