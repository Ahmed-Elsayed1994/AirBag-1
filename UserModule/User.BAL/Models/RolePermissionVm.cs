using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class RolePermissionVm : IVM
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int FlgAC { get; set; }
        public string ModuleName { get; set; }
    }
}
