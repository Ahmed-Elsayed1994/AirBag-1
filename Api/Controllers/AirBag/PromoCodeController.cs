using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : BaseAPIController<IPromoCodeService, PromoCode, PromoCodeVm>
    {
        public PromoCodeController(IPromoCodeService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
        }
    }



}
