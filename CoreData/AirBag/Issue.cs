using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Issue: BaseEntity
    {
        public int IssueCategoryId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("IssueCategoryId")]
        public virtual IssueCategory IssueCategory { get; set; }
    }
}
