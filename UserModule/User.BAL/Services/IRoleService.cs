using CoreData.Users.Entities;
using Framework.Core.UOW;
using System.Collections.Generic;
using User.BAL.Models;

namespace User.BAL.Services
{
   public interface IRoleService : IBusiness<CoreData.Users.Entities.Role,RoleVm>
    {
        IList<Role> GetRolesByIds(IList<int> RolesId);
        IList<Role> GetRoles();


    }
}
