using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IEvaluationWriteRepository
    {
        Task<Evaluation> InsertEvaluationAsync(Evaluation evaluation);
        System.Threading.Tasks.Task DeleteEvaluationAsync(int evaluationId);
        System.Threading.Tasks.Task UpdateEvaluationAsync(Evaluation evaluation);
    }
}
