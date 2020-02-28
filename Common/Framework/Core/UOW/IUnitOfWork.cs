using CoreData.Users.Entities;
using Framework.Basic;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using System.Threading.Tasks;

namespace Framework.Core.UOW
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IRepository<Airline> AirLine { get; }
        IRepository<AirPort> AirPort { get; }
        IRepository<Bag> Bag { get; }
        IRepository<City> City { get; }
        IRepository<Country> Country { get; }
        IRepository<Issue> Issue { get; }
        IRepository<IssueCategory> IssueCategory { get; }
        IRepository<Item> Item { get; }
        IRepository<ItemCategory> ItemCategory { get; }
        IRepository<ManagementNotes> ManagementNotes { get; }
        IRepository<MobileCountryCode> MobileCountryCode { get; }
        IRepository<Rate> Rate { get; }
        IRepository<Invitation> Invitation { get; }
        IRepository<PromoCode> PromoCode { get; }
        IRepository<Request> Request { get; }
        IRepository<RequestDetails> RequestDetails { get; }
        IRepository<RequestType> RequestType { get; }
        IRepository<Transaction> Transaction { get; }
        IRepository<UnWantedBagCategory> UnWantedBagCategory { get; }
        IRepository<Nationality> Nationality { get; }




        SaveResult SaveResult { get;  }
        void Dispose();
        Task<int> Save();
        void AddError(int code, string error);
        void AddError(Error error);
    }
}