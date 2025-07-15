using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class WeekReadRepository : IWeekReadRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public WeekReadRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }

        public async Task<IEnumerable<Week>> GetWeeksByUserIdAsync(int userId)
        {
            return await _ecoleDeLaPerformancePreprodContext.Weeks
                         .Include(x => x.HalfDayPlannings)
                         .Where(c => c.UserId == userId)
                         .OrderBy(x => x.WeekNumber)
                         .ToListAsync();
        }

    }
}
