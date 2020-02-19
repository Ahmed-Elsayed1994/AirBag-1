using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreData.RiskManagement.Common
{
   public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string TableName { get; set; }
        public int RefId { get; set; }
    }
}
