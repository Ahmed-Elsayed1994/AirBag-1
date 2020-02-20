﻿using Framework.Core;
using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class BagVm : IVM
    {
        public string Name { get; set; }
        public int AirPortCompanyId { get; set; }
        public int AirPortTakeOffId { get; set; }
        public int ArrivalAirPortId { get; set; }
        public DateTime DateTimeTakeOff { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string AirPortTakeOffName { get; set; }
        public string ArrivalAirPortName { get; set; }
        public string TripNumber { get; set; }
        public decimal AvailableWeight { get; set; }
        public decimal Weight { get; set; }
        public decimal CostPerKG { get; set; }
        public string TiketPhotoId { get; set; }
        public bool Boost { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AirPortCaompanyName { get; set; }
        public IList<UnWantedBagCategoryVm> UnWantedBagCategories { get; set; }
    }
}