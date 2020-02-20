using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class MobileCountryCode : BaseEntity
    {
        public string CountryCode { get; set; }
    }
}
