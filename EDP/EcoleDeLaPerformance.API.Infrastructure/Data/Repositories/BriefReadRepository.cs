using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class BriefReadRepository : IBriefReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public BriefReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<List<Brief?>> GetBriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var result = await _parcoursPerformanceCommercialeContext.Briefs
            .Where(x => x.UserId == userId &&
            x.CreatedAt >= startDateWeek &&
            x.CreatedAt <= endDateWeek)
            .ToListAsync();

            return result;
        }
    }
}
