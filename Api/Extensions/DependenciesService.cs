using Framework.Core.Repo;
using Framework.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Framework.Core.UOW;
using User.BAL.Services;
using CoreData.Users.Entities;
using Microsoft.AspNetCore.Identity;
using User.BAL.Models;
using RiskManagement.BAL.Services.Common;
using NotificationManagement.Services;
using Microsoft.AspNetCore.Http;
using Api.Filters;
using Persistence.UnitOfWork;
using Framework.Core.Repo.Interfaces;
using Persistence.Repositories;
using NotificationManagement.Models;

namespace Api.Extensions
{
    public static class DependenciesService
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<TokenProvider>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Persistence.Repositories.Repository<>));
            services.AddTransient<UserManager<CoreData.Users.Entities.User>>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IAccountService, AccountService>();
           // services.AddScoped<CoreData.DynForms.Repositories.IFormsMasterRepository, CoreData.DynForms.Repositories.FormsMasterRepository>();
            services.AddTransient<IRoleService, RoleService>();
          //  services.AddScoped<CoreData.DynForms.Repositories.IFormsMasterRepository, CoreData.DynForms.Repositories.FormsMasterRepository>();
            services.AddTransient<IImageUpload, ImagesUpload>();
            services.AddTransient<IPushNotificationService, PushNotificationService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddSingleton<IMSMemoryCash, MSMemoryCash>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ActionFilter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
            services.AddTransient<ISendNotificationService, SendingNotificationService>();
            services.AddTransient<INotificationManagementService, NotificationManagementService>();
        }
    }
}
