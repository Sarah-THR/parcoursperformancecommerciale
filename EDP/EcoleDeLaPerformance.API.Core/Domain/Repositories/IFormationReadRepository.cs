using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IFormationReadRepository
    {
        Task<List<Formation?>> GetFormationsAsync();
    }
}
