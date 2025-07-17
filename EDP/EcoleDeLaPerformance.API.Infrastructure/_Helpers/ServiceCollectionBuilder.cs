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
            services.AddScoped<IUsersFormationWriteRepository, UsersFormationWriteRepository>();
            services.AddScoped<IBriefWriteRepository, BriefWriteRepository>();
            services.AddScoped<IBriefReadRepository, BriefReadRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IDebriefReadRepository, DebriefReadRepository>();
            services.AddScoped<IDebriefWriteRepository, DebriefWriteRepository>();
            services.AddScoped<IEvaluationReadRepository, EvaluationReadRepository>();
            services.AddScoped<IEvaluationWriteRepository, EvaluationWriteRepository>();
            services.AddScoped<IFormationReadRepository, FormationReadRepository>();
            services.AddScoped<IGradeReadRepository, GradeReadRepository>();
            services.AddScoped<IGradeWriteRepository, GradeWriteRepository>();
            services.AddScoped<IFormationWriteRepository, FormationWriteRepository>();
            services.AddScoped<ITaskReadRepository, TaskReadRepository>();
            services.AddScoped<IStatusReadRepository, StatusReadRepository>();
            services.AddScoped<IPlanningReadRepository, PlanningReadRepository>();
            services.AddScoped<IPlanningWriteRepository, PlanningWriteRepository>();
            services.AddScoped<ITurnoverReadRepository, TurnoverReadRepository>();
            services.AddScoped<IDocumentWriteRepository, DocumentWriteRepository>();
            services.AddScoped<IDocumentReadRepository, DocumentReadRepository>();
            services.AddScoped<IDebitAccountReadRepository, DebitAccountReadRepository>();
            services.AddScoped<IContractReadRepository, ContractReadRepository>();
        }
    }
}
