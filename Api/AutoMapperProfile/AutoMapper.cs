using AutoMapper;
using CoreData.Users.Entities;

namespace Api.AutoMapperProfile
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CoreData.Users.Entities.Action, ActionVm>().ReverseMap();
            CreateMap<AirPort, AirPortVm>().ReverseMap();
            CreateMap<Airline, AirlineVm>().ReverseMap();
            CreateMap<Bag, BagVm>().ReverseMap();
            CreateMap<Card, CardVm>().ReverseMap();
            CreateMap<City, CityVm>().ReverseMap();
            CreateMap<Country, CountryVm>().ReverseMap();
            CreateMap<Issue, IssueVm>().ReverseMap();
            CreateMap<IssueCategory, IssueCategoryVm>().ReverseMap();
            CreateMap<Item, ItemVm>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoryVm>().ReverseMap();
            CreateMap<ManagementNotes, ManagementNotesVm>().ReverseMap();
            CreateMap<MobileCountryCode, MobileCountryCodeVm>().ReverseMap();
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
