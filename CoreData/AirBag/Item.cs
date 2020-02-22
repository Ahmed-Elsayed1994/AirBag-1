using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int? ItemCategoryId { get; set; }
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool Boost { get; set; }

        public DateTime DateTimeTakeOff { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Hieght { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Length { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Width { get; set; }
        public string Dscription { get; set; }
        public string Link { get; set; }
        public string PhotosIds { get; set; }
        public bool IsActive { get; set; }
        public int? ManagementApprovedStatusId { get; set; }
        public int? RequestApprovedStatusId { get; set; }
        public int? ApprovedByUserId{ get; set; }
        public DateTime ApprovedDateTime { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ItemCategoryId")]
        public virtual ItemCategory ItemCategory { get; set; }
        [ForeignKey("AirPortTakeOffId")]
        public virtual AirPort AirPortTakeOff { get; set; }
        [ForeignKey("ArrivalAirPortId")]
        public virtual AirPort ArrivalAirPort { get; set; }
        public virtual ICollection<RequestDetails> RequestDetails { get; set; }


        [ForeignKey("ManagementApprovedStatusId")]
        public virtual Status ManagementApprovedStatus { get; set; }

        [ForeignKey("RequestApprovedStatusId")]
        public virtual Status RequestApprovedStatus { get; set; }

        [ForeignKey("ApprovedByUserId")]
        public virtual User ApprovedUser{ get; set; }
    }
}
