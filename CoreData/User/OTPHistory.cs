using Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class OTPHistory: BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
