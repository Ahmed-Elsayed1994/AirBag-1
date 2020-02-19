using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Base;
using Framework.Core.UOW;
using Framework.Helpers;
using User.BAL.Services;
using User.BAL.Models;

namespace Api.Controllers.Permissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseAPIController<IRoleService, CoreData.Users.Entities.Role, RoleVm>
    {

        public RolesController(IRoleService roleService, IUnitOfWork unitOfWork) : base(unitOfWork,roleService)
        {

        }
    }
}