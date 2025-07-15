using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class DebriefWriteRepository : IDebriefWriteRepository
    {

        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public DebriefWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Debrief> InsertDebriefAsync(Debrief debrief)
        {
            _parcoursPerformanceCommercialeContext.Debriefs.Add(debrief);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return debrief;
        }
        public async System.Threading.Tasks.Task DeleteDebriefAsync(int debriefId)
        {
            await _parcoursPerformanceCommercialeContext.Debriefs.Where(p => p.Id == debriefId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateDebriefAsync(Debrief debrief)
        {
            _parcoursPerformanceCommercialeContext.Debriefs.Update(debrief);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
