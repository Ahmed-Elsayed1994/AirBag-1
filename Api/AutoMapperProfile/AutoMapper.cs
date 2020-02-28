using AutoMapper;
using CoreData.Users.Entities;
using System;

namespace Api.AutoMapperProfile
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CoreData.Users.Entities.User, User.BAL.Models.BaseUser>();
            CreateMap<User.BAL.Models.UserVM, CoreData.Users.Entities.User>().ForMember(a=> a.CreatedDateTime, from=> from.MapFrom(src=> DateTime.UtcNow));
            CreateMap<CoreData.Users.Entities.Action, ActionVm>().ReverseMap();
            CreateMap<AirPort, AirPortVm>();
            CreateMap<AirPort, AirPortPartial>();

            CreateMap<AirPortVm, AirPort>();
            CreateMap<Airline, AirlineVm>().ReverseMap();
            CreateMap<Bag, BagVm>();
            CreateMap<Bag, BagPartial>();

            CreateMap<BagVm, Bag>();
            CreateMap<Card, CardVm>();
            CreateMap<CardVm, Card>();
            CreateMap<City, CityVm>().ForMember(a=> a.CountryName, from=> from.MapFrom(a=> a.Country.Name));
            CreateMap<CityVm, City>();
            CreateMap<NationalityVm, Nationality>();
            CreateMap<Nationality, NationalityVm>();

            // CreateMap<CityVm, City>().ForMember(a => a.Country, from => from.MapFrom(a => _unitOfWork.Country.GetById(a.CountryId)));
            CreateMap<Country, CountryVm>().ReverseMap();
            CreateMap<Issue, IssueVm>();
            CreateMap<IssueVm, Issue>();
            CreateMap<IssueCategory, IssueCategoryVm>().ReverseMap();
            CreateMap<Item, ItemVm>();
            CreateMap<ItemVm, Item>();
            CreateMap<Item, ItemPartial>();
            CreateMap<ItemCategory, ItemCategoryVm>().ReverseMap();
            CreateMap<ManagementNotes, ManagementNotesVm>();
            CreateMap<ManagementNotesVm, ManagementNotes>();

            CreateMap<MobileCountryCode, MobileCountryCodeVm>();
            CreateMap<MobileCountryCodeVm, MobileCountryCode>();

            CreateMap<PromoCode, PromoCodeVm>().ReverseMap();
            CreateMap<Rate, RateVm>().ReverseMap();
            CreateMap<Request, RequestVm>().ReverseMap();
            CreateMap<RequestDetails, RequestDetailsVm>().ReverseMap();
            CreateMap<RequestType, RequestTypeVm>().ReverseMap();
            CreateMap<Transaction, TransactionVm>().ReverseMap();
            CreateMap<UnWantedBagCategory, UnWantedBagCategoryVm>().ReverseMap();
        }
    }
}
