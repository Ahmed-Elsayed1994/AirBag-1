using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class RolePermissionHierarchy : IVM
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public Permission Permission { get; set; }
    }
}
