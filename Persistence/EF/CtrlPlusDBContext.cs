using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EntityModule = CoreData.Users.Entities;
using CoreData.Users.Entities;
using CoreData.RiskManagement.Common;
using Microsoft.Extensions.Configuration;
using CoreData.Common.Entities.Notifications;
using Framework.Core;
using System.Reflection;

namespace Persistence.EF
{
    public class CtrlPlusDbContext : DbContext, ICtrlPlusDbContext
    {
        public virtual DbSet<EntityModule.User> Users { get; set; }
        public virtual DbSet<EntityModule.Role> Roles { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<AirPort> AirPorts { get; set; }
        public virtual DbSet<Airline> AirPortCompanies { get; set; }
        public virtual DbSet<Bag> Bags { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueCategory> IssueCategories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ManagementNotes> ManagementNotes { get; set; }
        public virtual DbSet<MobileCountryCode> MobileCountryCodes { get; set; }
        public virtual DbSet<PromoCode> PromoCodes { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestDetails> RequestDetails { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Transaction> PaymentTransactions { get; set; }
        public virtual DbSet<UnWantedBagCategory> UnWantedBagCategories { get; set; }
        public virtual DbSet<Card> Cards { get; set; }

        public CtrlPlusDbContext(DbContextOptions<CtrlPlusDbContext> options):base(options)
        {

        }
        

        //config;
        private readonly IConfiguration _configuration;
        public CtrlPlusDbContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
        }

        public CtrlPlusDbContext(DbContextOptions<CtrlPlusDbContext> options , IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
            Database.EnsureCreated();
        }
        public override int SaveChanges()
        {
            ApplyTrakingInfo();
            return base.SaveChanges();
        }

        private void ApplyTrakingInfo()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// For logging changings
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyTrakingInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
            }
            optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
        public Task<int> SaveChangesAsync()
        {
            ApplyTrakingInfo();
            return base.SaveChangesAsync();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public EntityEntry Entry<TEntity>(object entity) where TEntity : class
        {
            return base.Entry(entity);
        }
    }
}
