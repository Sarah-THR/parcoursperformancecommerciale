using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class FormationWriteRepository : IFormationWriteRepository
    {

        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public FormationWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Formation> InsertFormationAsync(Formation formation)
        {
            _parcoursPerformanceCommercialeContext.Formations.Add(formation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return formation;
        }
        public async System.Threading.Tasks.Task DeleteFormationAsync(int formationId)
        {
            await _parcoursPerformanceCommercialeContext.Formations.Where(p => p.Id == formationId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateFormationAsync(Formation formation)
        {
            _parcoursPerformanceCommercialeContext.Formations.Update(formation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
