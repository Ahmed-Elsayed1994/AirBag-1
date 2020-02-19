using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
   public class ModuleTree : IVM
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public string Path { get; set; }
        public  IEnumerable<ModuleTree> Children { get; set; }
    }
}
