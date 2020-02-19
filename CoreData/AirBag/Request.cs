﻿using Framework.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Request : BaseEntity
    {
        public int RequestTypeId { get; set; }
        public int ActionId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string PromoCode { get; set; }
        public int UserId { get; set; }
        [ForeignKey("RequestTypeId")]
        public virtual RequestType RequestType { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}