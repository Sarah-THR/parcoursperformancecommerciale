using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class PlanningsTaskWriteRepository : IPlanningsTaskWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public PlanningsTaskWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<PlanningsTask> InsertPlanningsTaskAsync(PlanningsTask planningsTask)
        {
            _parcoursPerformanceCommercialeContext.PlanningsTasks.Add(planningsTask);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return planningsTask;
        }
        public async System.Threading.Tasks.Task UpdatePlanningsTaskAsync(PlanningsTask planningsTask)
        {
            _parcoursPerformanceCommercialeContext.PlanningsTasks.Update(planningsTask);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
