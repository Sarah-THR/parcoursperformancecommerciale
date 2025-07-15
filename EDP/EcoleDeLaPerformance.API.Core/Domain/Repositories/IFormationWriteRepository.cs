using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IFormationWriteRepository
    {
        Task<Formation> InsertFormationAsync(Formation formation);
        System.Threading.Tasks.Task DeleteFormationAsync(int formationId);
        System.Threading.Tasks.Task UpdateFormationAsync(Formation formation);
    }
}
