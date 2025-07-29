using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
            var existing = await _parcoursPerformanceCommercialeContext.PlanningsTasks.FirstOrDefaultAsync(pt => pt.PlanningId == planningsTask.PlanningId && pt.Identifier == planningsTask.Identifier);
            if (existing != null)
            {
                _parcoursPerformanceCommercialeContext.PlanningsTasks.Remove(existing);
                await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            }
            if (planningsTask.Identifier.StartsWith("Task"))
            {
                _parcoursPerformanceCommercialeContext.PlanningsTasks.Remove(planningsTask);
                await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            }
            else
            {
                _parcoursPerformanceCommercialeContext.PlanningsTasks.Add(planningsTask);
                await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            }

            return planningsTask;
        }
        public async System.Threading.Tasks.Task UpdatePlanningsTaskAsync(PlanningsTask planningsTask)
        {
            _parcoursPerformanceCommercialeContext.PlanningsTasks.Update(planningsTask);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
