using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagController : BaseAPIController<IBagService, Bag, BagVm>
    {
        public BagController(IBagService bagService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, bagService)
        {
        }
    }



}
