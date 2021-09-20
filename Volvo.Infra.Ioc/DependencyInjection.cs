using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Application.Interfaces;
using Volvo.Application.Services;
using Volvo.Domain.Interfaces.Repositories;
using Volvo.Infra.Data.Context;
using Volvo.Infra.Data.Repositories;

namespace Volvo.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfig(this IServiceCollection services,
                                                   IConfiguration Configuration)
        {            
            services.AddDbContext<DbTruckContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DbTruckContext>();

            services.AddScoped<ITruckRepository, TruckRepository>();

            services.AddScoped<ITruckService, TruckService>();

            return services;
        }

        public static IApplicationBuilder AddConfigure(this IApplicationBuilder app)
        {

            using (var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                migrationSvcScope.ServiceProvider.GetService<DbTruckContext>().Database.Migrate();
            }

            return app;
        }
    }
}
