using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class PlanningWriteRepository : IPlanningWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public PlanningWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Planning> InsertPlanningAsync(Planning planning)
        {
            _parcoursPerformanceCommercialeContext.Plannings.Add(planning);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return planning;
        }
        public async System.Threading.Tasks.Task DeletePlanningAsync(int planningId)
        {
            await _parcoursPerformanceCommercialeContext.Plannings.Where(p => p.Id == planningId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdatePlanningAsync(Planning planning)
        {
            _parcoursPerformanceCommercialeContext.Plannings.Update(planning);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
