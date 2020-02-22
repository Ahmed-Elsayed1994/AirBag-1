using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : BaseAPIController<IPaymentTransaction, Transaction, TransactionVm>
    {
        public PaymentTransactionController(IPaymentTransaction service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
        }
    }



}
