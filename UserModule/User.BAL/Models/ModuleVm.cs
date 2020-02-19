using Framework.Core.Model;
//using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace User.BAL.Models
{
    public class ModuleVm : IVM
    {
        //[BindNever]
        public int Id { get;  set ; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string TypeId { get; set; }
        public string Path { get; set; }
        public string ParentName { get; set; }
    }
}
