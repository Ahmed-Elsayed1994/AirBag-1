using AirBag.BAL.Interfaces;
using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;

namespace User.BAL.Services
{
    public class PaymentTransactionService : BaseService<Transaction, TransactionVm>, IPaymentTransaction
    {
        public PaymentTransactionService(IRepository<Transaction> repository, IUnitOfWork unitOfWork, IMapper mapper
            )
            : base(repository, unitOfWork,mapper)
        {
        }

      
    }
}
