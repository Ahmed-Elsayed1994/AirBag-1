using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;

namespace User.BAL.Services
{
    public class PromoCodeService : BaseService<PromoCode, PromoCodeVm>, IPromoCodeService
    {
        public PromoCodeService(IRepository<PromoCode> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

      
    }
}
