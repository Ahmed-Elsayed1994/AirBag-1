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
using Persistence.EntityConfiguration;

namespace Persistence.EF
{
    public class CtrlPlusDbContext : DbContext, ICtrlPlusDbContext
    {
        public virtual DbSet<EntityModule.User> Users { get; set; }
        public virtual DbSet<EntityModule.Role> Roles { get; set; }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<Subscriptions> Subscriptions { get; set; }

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

        [DbFunction("GetLocalized")]
        public static string Localize(int EntityId, string TableName, string ColumnName, string Language, string Default)
        {
            throw new System.Exception(); // this code doesn't get executed; the call is passed through to the database function
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
