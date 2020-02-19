using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class RoleVm : IVM
    {
        public int Id { get; set; }
        public string  Name { get; set; }
    }
}
