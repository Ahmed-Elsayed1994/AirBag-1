using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileCountryCodeController : BaseAPIController<IMobileCountryCodeService, MobileCountryCode, MobileCountryCodeVm>
    {
        public MobileCountryCodeController(IMobileCountryCodeService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
        }
    }



}
