using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Infrastructure.Data;
using EcoleDeLaPerformance.API.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcoleDeLaPerformance.API.Infrastructure._Helpers
{
    public static class ServiceCollectionBuilder
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var preprodConnectionString = configuration["ConnectionStrings:PreprodConnection"];
            var crmConnectionString = configuration["ConnectionStrings:CRMConnection"];
            var biConnectionString = configuration["ConnectionStrings:BIConnection"];

            services.AddDbContext<ParcoursPerformanceCommercialeContext>(options =>
                options.UseSqlServer(preprodConnectionString, b => b.MigrationsAssembly("EcoleDeLaPerformance.API.Host")));

            services.AddDbContext<XefiMscrmContext>(options =>
                options.UseSqlServer(crmConnectionString, b => b.MigrationsAssembly("EcoleDeLaPerformance.API.Host")));

            services.AddDbContext<BiContext>(options =>
            options.UseSqlServer(biConnectionString, b => b.MigrationsAssembly("EcoleDeLaPerformance.API.Host")));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IWeekReadRepository, WeekReadRepository>();
            services.AddScoped<IWeekWriteRepository, WeekWriteRepository>();
            services.AddScoped<IHalfDayPlanningReadRepository, HalfDayPlanningReadRepository>();
            services.AddScoped<IHalfDayPlanningWriteRepository, HalfDayPlanningWriteRepository>();
            services.AddScoped<IClassReadRepository, ClassReadRepository>();
            services.AddScoped<IBriefWriteRepository, BriefWriteRepository>();
            services.AddScoped<IBriefReadRepository, BriefReadRepository>();
            services.AddScoped<ITurnoverReadRepository, TurnoverReadRepository>();
            services.AddScoped<IDocumentWriteRepository, DocumentWriteRepository>();
            services.AddScoped<IDocumentReadRepository, DocumentReadRepository>();
            services.AddScoped<IDebitAccountReadRepository, DebitAccountReadRepository>();
            services.AddScoped<ITaskPlanningReadRepository, TaskPlanningReadRepository>();
            services.AddScoped<IContractReadRepository, ContractReadRepository>();
        }
    }
}
