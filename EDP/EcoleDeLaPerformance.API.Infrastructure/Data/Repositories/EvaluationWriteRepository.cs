using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class EvaluationWriteRepository : IEvaluationWriteRepository
    {

        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public EvaluationWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Evaluation> InsertEvaluationAsync(Evaluation evaluation)
        {
            _parcoursPerformanceCommercialeContext.Evaluations.Add(evaluation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return evaluation;
        }
        public async System.Threading.Tasks.Task DeleteEvaluationAsync(int evaluationId)
        {
            await _parcoursPerformanceCommercialeContext.Evaluations.Where(p => p.Id == evaluationId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateEvaluationAsync(Evaluation evaluation)
        {
            _parcoursPerformanceCommercialeContext.Evaluations.Update(evaluation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
