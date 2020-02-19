using Api.Controllers.Base;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Mvc;
using User.BAL.Models;
using User.BAL.Services;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseAPIController<IUsersService, CoreData.Users.Entities.User, UserVM>
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, usersService)
        {
            _usersService = usersService;
        }
    }



}
