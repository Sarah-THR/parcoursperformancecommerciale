using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class DebriefReadRepository : IDebriefReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public DebriefReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<List<Debrief?>> GetDebriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var result = await _parcoursPerformanceCommercialeContext.Debriefs
            .Where(x => x.UserId == userId &&
            x.CreatedAt >= startDateWeek &&
            x.CreatedAt <= endDateWeek)
            .ToListAsync();

            return result;
        }
    }
}
