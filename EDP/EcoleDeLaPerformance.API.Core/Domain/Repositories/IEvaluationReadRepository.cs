using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IEvaluationReadRepository
    {
        Task<List<Evaluation?>> GetEvaluationsAsync();
    }
}
