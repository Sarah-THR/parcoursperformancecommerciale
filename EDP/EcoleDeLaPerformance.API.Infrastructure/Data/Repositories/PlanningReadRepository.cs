using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class PlanningReadRepository : IPlanningReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public PlanningReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<List<Planning?>> GetPlanningByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var result = await _parcoursPerformanceCommercialeContext.Plannings
                .Include(x => x.PlanningsTasks)
                .ThenInclude(x => x.Task)
                .Where(x => x.UserId == userId &&
                    x.CreatedAt >= startDateWeek &&
                    x.CreatedAt <= endDateWeek)
                .ToListAsync();

            return result;
        }
    }
}
