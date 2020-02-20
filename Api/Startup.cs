using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Api.Middlewares;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Api.Extensions;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory logger)
        {
            Configuration = configuration;
            _logger = logger.CreateLogger<Startup>();
        }

        public IConfiguration Configuration { get; }
        private ILogger _logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
            services.AddMemoryCache();
            services.AddRouting();
            services.ConfigureDependencies();
            services.ConfigureDbContext(Configuration); /* Get Conniction string */
            services.ConfigureJWT(Configuration);  // configure jwt authentication
            services.ConfigureSwagger(); //configure swagger
            services.ConfigureWebPushService(Configuration); // configure vapidDetails for push notification
            services.ConfigureEmailService(Configuration);
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
            });
            services.ConfigureAutoMapperService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler(_logger);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseDefaultFiles();
            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}