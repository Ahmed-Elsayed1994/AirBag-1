using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.BAL.Models
{
    public class UserVM : IVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "ERQ_ERR")]
        public string Passowrd { get; set; }
        public IList<int> SysModuleIds { get; set; }
        public IList<int> UnitsIds { get; set; }
        public IList<int> RolesIds { get; set; }

        public IList<RoleVm> Roles { get; set; }

        public IList<UserPermissionsVm> UserPermissionVms { get; set; }
    }
}