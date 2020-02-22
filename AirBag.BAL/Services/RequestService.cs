using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;

namespace User.BAL.Services
{
    public class RequestService : BaseService<Request, RequestVm>, IRequestService
    {
        public RequestService(IRepository<Request> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

      
    }
}
