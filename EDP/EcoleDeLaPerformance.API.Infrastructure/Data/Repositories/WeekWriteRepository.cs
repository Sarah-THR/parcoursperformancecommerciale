using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class WeekWriteRepository : IWeekWriteRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public WeekWriteRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }
        public async Task<Week> CreateWeekAsync(Week week)
        {
            _ecoleDeLaPerformancePreprodContext.Add(week);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
            return week;
        }

        public async System.Threading.Tasks.Task UpdateWeekAsync(Week week)
        {
            _ecoleDeLaPerformancePreprodContext.Weeks.Update(week);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
        }
    }
}
