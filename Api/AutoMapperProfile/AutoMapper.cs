using AutoMapper;
using CoreData.Users.Entities;
using Framework.Core.UOW;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EF;
using Persistence.UnitOfWork;
using System;

namespace Api.AutoMapperProfile
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CoreData.Users.Entities.Action, ActionVm>().ReverseMap();
            CreateMap<AirPort, AirPortVm>();
            CreateMap<AirPortVm, AirPort>();
            CreateMap<Airline, AirlineVm>().ReverseMap();
            CreateMap<Bag, BagVm>();
            CreateMap<BagVm, Bag>();
            CreateMap<Card, CardVm>();
            CreateMap<CardVm, Card>();
            CreateMap<City, CityVm>().ForMember(a=> a.CountryName, from=> from.MapFrom(a=> a.Country.Name));
            CreateMap<CityVm, City>();
            
           // CreateMap<CityVm, City>().ForMember(a => a.Country, from => from.MapFrom(a => _unitOfWork.Country.GetById(a.CountryId)));
            CreateMap<Country, CountryVm>().ReverseMap();
            CreateMap<Issue, IssueVm>();
            CreateMap<IssueVm, Issue>();
            CreateMap<IssueCategory, IssueCategoryVm>().ReverseMap();
            CreateMap<Item, ItemVm>();
            CreateMap<ItemVm, Item>().ForMember(a=> a.CreatedDate, from=> from.MapFrom(src => DateTime.UtcNow));
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
