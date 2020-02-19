using CoreData.Common.Notifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.BAL.Models;

namespace Api.Extensions
{
    public static class EmailService
    {
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
        }
    }
}
