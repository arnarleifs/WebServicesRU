using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RU.WebServices.SecretService.API.Middlewares;
using RU.WebServices.SecretService.Repositories.Contexts;
using RU.WebServices.SecretService.Repositories.Implementations;
using RU.WebServices.SecretService.Repositories.Interfaces;
using RU.WebServices.SecretService.Services.Implementations;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<SecretServiceDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SecretServiceDatabase"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            });

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtTokenAuthentication(Configuration);

            var jwtConfig = Configuration.GetSection("JwtConfig");
            services.AddTransient<ITokenService>((c) =>
                new TokenService(
                    jwtConfig.GetSection("secret").Value,
                    jwtConfig.GetSection("expirationInMinutes").Value,
                    jwtConfig.GetSection("issuer").Value,
                    jwtConfig.GetSection("audience").Value));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
