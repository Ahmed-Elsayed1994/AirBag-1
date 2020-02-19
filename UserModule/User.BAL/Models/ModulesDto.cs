using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace User.BAL.Models
{
    public class ModulesDto 
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        [Required(ErrorMessage = "TypeId is Required")]
        public string TypeId { get; set; }

        public string Path { get; set; }
    }
}
