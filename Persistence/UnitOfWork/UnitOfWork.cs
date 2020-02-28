using CoreData.Users.Entities;
using Framework.Basic;
using Framework.Core;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ICtrlPlusDbContext context;
        private bool disposed = false;
        public SaveResult SaveResult { get; set; }

        public UnitOfWork(ICtrlPlusDbContext _context)
        {
            context = _context;
            SaveResult = new SaveResult();
        }

        #region repositories

        #region fields
        private IUsersRepository _usersRepository;

        private IRepository<Airline> _airLineRepository;
        IRepository<AirPort> _airPortRepository;
        IRepository<Bag> _bagRepository;
        IRepository<City> _cityRepository;
        IRepository<Country> _country;
        IRepository<Issue> _issue;
        IRepository<IssueCategory> _issueCategory;
        IRepository<Item> _item;
        IRepository<ItemCategory> _itemCategory;
        IRepository<ManagementNotes> _managementNotes;
        IRepository<MobileCountryCode> _mobileCountryCode;
        IRepository<Rate> _rate;
        IRepository<Invitation> _invitation;
        IRepository<PromoCode> _promoCode;
        IRepository<Request> _request;
        IRepository<RequestDetails> _requestDetails;
        IRepository<RequestType> _requestType;
        IRepository<Transaction> _transaction;
        IRepository<UnWantedBagCategory> _unWantedBagCategory;
        IRepository<Nationality> _nationality;
        #endregion

        #region Properties
        public IUsersRepository Users => _usersRepository = _usersRepository ?? new UsersRepository(context);

        public IRepository<Airline> AirLine => _airLineRepository = _airLineRepository ?? new Repository<Airline>(context);

        public IRepository<AirPort> AirPort => _airPortRepository = _airPortRepository ?? new Repository<AirPort>(context);

        public IRepository<Bag> Bag => _bagRepository = _bagRepository ?? new Repository<Bag>(context);

        public IRepository<City> City => _cityRepository = _cityRepository ?? new Repository<City>(context);

        public IRepository<Country> Country => _country = _country ?? new Repository<Country>(context);

        public IRepository<Issue> Issue => _issue = _issue ?? new Repository<Issue>(context);

        public IRepository<IssueCategory> IssueCategory => _issueCategory = _issueCategory ?? new Repository<IssueCategory>(context);

        public IRepository<Item> Item => _item = _item ?? new Repository<Item>(context);

        public IRepository<ItemCategory> ItemCategory => _itemCategory = _itemCategory ?? new Repository<ItemCategory>(context);

        public IRepository<ManagementNotes> ManagementNotes => _managementNotes = _managementNotes ?? new Repository<ManagementNotes>(context);

        public IRepository<MobileCountryCode> MobileCountryCode => _mobileCountryCode = _mobileCountryCode ?? new Repository<MobileCountryCode>(context);

        public IRepository<Rate> Rate => _rate = _rate ?? new Repository<Rate>(context);

        public IRepository<Invitation> Invitation => _invitation = _invitation ?? new Repository<Invitation>(context);

        public IRepository<PromoCode> PromoCode => _promoCode = _promoCode ?? new Repository<PromoCode>(context);

        public IRepository<Request> Request => _request = _request ?? new Repository<Request>(context);

        public IRepository<RequestDetails> RequestDetails => _requestDetails = _requestDetails ?? new Repository<RequestDetails>(context);

        public IRepository<RequestType> RequestType => _requestType = _requestType ?? new Repository<RequestType>(context);

        public IRepository<Transaction> Transaction => _transaction = _transaction ?? new Repository<Transaction>(context);

        public IRepository<UnWantedBagCategory> UnWantedBagCategory => _unWantedBagCategory = _unWantedBagCategory ?? new Repository<UnWantedBagCategory>(context);

        public IRepository<Nationality> Nationality => _nationality = _nationality ?? new Repository<Nationality>(context);
        #endregion

        #endregion

        public async Task<int> Save()
        {
            int returnNum = 0;
            try
            {
                returnNum = await context.SaveChangesAsync();
                SaveResult.Affected = returnNum;
                return returnNum;
            }
            catch (Exception e)
            {
                AddError(new Error(500, e.Message.ToString()));
            }
            return returnNum;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddError(int code, string error)
        {
            SaveResult.Errors.Add(new Error(code, error));
        }
        public void AddError(Error error)
        {
            SaveResult.Errors.Add(error);
        }
    }
}
