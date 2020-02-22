using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;

namespace User.BAL.Services
{
    public class CardService : BaseService<Card, CardVm>, ICardService
    {
        public CardService(IRepository<Card> repository , IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {
        }

      
    }
}
