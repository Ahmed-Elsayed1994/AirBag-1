using Framework.Core;
using Framework.Core.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class IssueVm: IVM
    {
        public int IssueCategoryId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string IssueCategoryName { get; set; }
    }
}
