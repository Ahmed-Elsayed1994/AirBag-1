using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseAPIController<ICityService, City, CityVm>
    {
        public CityController(ICityService cityService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, cityService)
        {
        }
    }



}
