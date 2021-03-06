﻿using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class Bag : BaseEntity
    {
        public string Name { get; set; }
        public int? AirPortCompanyId { get; set; }
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public DateTime DateTimeTakeOff { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime ApprovedDateTime { get; set; }

        public string TripNumber { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AvailableWeight { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal CostPerKG { get; set; }
        public string TiketPhotoId { get; set; }
        public bool Boost { get; set; }
        public bool IsActive { get; set; }
        public int? ManagementApprovedStatusId { get; set; }
        public int? RequestApprovedStatusId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("AirPortTakeOffId")]
        public virtual AirPort AirPortTakeOff { get; set; }
        [ForeignKey("ArrivalAirPortId")]
        public virtual AirPort ArrivalAirPort { get; set; }
        [ForeignKey("AirPortCompanyId")]
        public virtual Airline AirPortCaompany { get; set; }
        public virtual ICollection<UnWantedBagCategory> UnWantedBagCategories { get; set; }

        [ForeignKey("ManagementApprovedStatusId")]
        public virtual Status ManagementApprovedStatus { get; set; }

        [ForeignKey("RequestApprovedStatusId")]
        public virtual Status RequestApprovedStatus { get; set; }

        [ForeignKey("ApprovedByUserId")]
        public virtual User ApprovedUser { get; set; }
    }
}
