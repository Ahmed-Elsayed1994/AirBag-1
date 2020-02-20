using Framework.Core.Model;
using System;

namespace CoreData.Users.Entities
{
    public class ManagementNotesVm : IVM
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
    }
}
