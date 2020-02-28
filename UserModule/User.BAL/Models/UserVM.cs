using CoreData.Users.Entities;
using Framework.Core.Model;
using System;
using System.Collections.Generic;

namespace User.BAL.Models
{
    public class UserVM : IVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureFileId { get; set; }
        public string CoverPictureFileId { get; set; }
        public int? CountryId { get; set; }
        public int? NationalityId { get; set; }
    }

    public class BaseUser: UserVM
    {
     
        public bool SenderMore { get; set; }
        public bool CarrierMore { get; set; }
        public bool IsActivated { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public decimal Rate { get; set; }
        public string CountryName { get; set; }
        public string NationalityName { get; set; }
        public  IList<RateVm> Rates { get; set; }
        public  IList<IssueVm> Issues { get; set; }
        public  IList<BagVm> Bags { get; set; }
        public  IList<ItemVm> Items { get; set; }
        public  IList<ManagementNotesVm> ManagementNotes { get; set; }
        public  IList<CardVm> Cards { get; set; }
        public  IList<RateVm> MyRates { get; set; }
        public  IList<InvitationVm> Invitations { get; set; }
        public  IList<InvitationVm> MyInvitations { get; set; }
        public  IList<ItemVm> ApprovedItems { get; set; }
        public  IList<BagVm> ApprovedBags { get; set; }
    }
}