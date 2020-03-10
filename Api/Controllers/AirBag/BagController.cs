using AirBag.BAL.Interfaces;
using Api.Controllers.Base;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]

    public class BagController : BaseAPIController<IBagService, Bag, BagVm>
    {
        private readonly IBagService _bagService;

        public BagController(IBagService bagService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, bagService)
        {
            _bagService = bagService;
        }

        [HttpGet]
        [Route("MyBags")]
        public IActionResult MyBags()
        {
          
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == null)
                return BadRequest("No User Found");
            return Ok(_bagService.MyBags(int.Parse( userId)));
        }
    }



}
