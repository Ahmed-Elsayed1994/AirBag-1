using Framework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EF;

namespace Api.Extensions
{
    public static class DbContextService
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration )
        {
            var connectionString = Configuration.GetConnectionString("Default");
            var FormsConnectionString = Configuration.GetConnectionString("FormsConnectionString");
            services.AddDbContext<ICtrlPlusDbContext, CtrlPlusDbContext>(options =>
             options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistence")));
        }
    }
}
