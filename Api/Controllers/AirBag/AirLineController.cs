using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirLineController : BaseAPIController<IAirlineService, Airline, AirlineVm>
    {
        public AirLineController(IAirlineService airLineService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, airLineService)
        {
        }
    }



}
