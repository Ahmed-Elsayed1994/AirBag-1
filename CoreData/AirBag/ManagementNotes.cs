using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class ManagementNotes : BaseEntity
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
