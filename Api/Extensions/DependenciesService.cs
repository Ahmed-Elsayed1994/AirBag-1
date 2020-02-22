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
using AirBag.BAL.Interfaces;

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


            #region airbag
            services.AddTransient<IAirlineService, AirLineService>();
            services.AddTransient<IAirPortService, AirPortService>();
            services.AddTransient<IBagService, BagService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IIsueCategoryService, IssueCategoryService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IItemService, ItemService>();

            services.AddTransient<IItemCategoryService, ItemCategoryService>();
            services.AddTransient<IManagementNotes, ManagementNotesService>();
            services.AddTransient<IMobileCountryCodeService, MobileCountryCodeService>();
            services.AddTransient<IPaymentTransaction, PaymentTransactionService>();
            services.AddTransient<IPromoCodeService, PromoCodeService>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IRequestService, RequestService>();

            #endregion
        }
    }
}
