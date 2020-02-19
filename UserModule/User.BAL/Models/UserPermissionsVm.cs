using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class UserPermissionsVm : IVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
