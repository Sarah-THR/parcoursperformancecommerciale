using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class BriefWriteRepository : IBriefWriteRepository
    {

        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public BriefWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Brief> InsertBriefAsync(Brief brief)
        {
            _parcoursPerformanceCommercialeContext.Briefs.Add(brief);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return brief;
        }
        public async System.Threading.Tasks.Task DeleteBriefAsync(int briefId)
        {
            await _parcoursPerformanceCommercialeContext.Briefs.Where(p => p.Id == briefId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateBriefAsync(Brief brief)
        {
            _parcoursPerformanceCommercialeContext.Briefs.Update(brief);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
