using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
   public class Permission
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string Type { get; set; }
        public Permission Parent { get; set; }
    }
}
