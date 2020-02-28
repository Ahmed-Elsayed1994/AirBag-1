using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : BaseAPIController<INationalityService, Nationality, NationalityVm>
    {
        public NationalityController(INationalityService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
        }
    }



}
