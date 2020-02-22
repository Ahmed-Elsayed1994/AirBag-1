using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirPortController : BaseAPIController<IAirPortService, AirPort, AirPortVm>
    {
        public AirPortController(IAirPortService airPortService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, airPortService)
        {
        }
    }



}
