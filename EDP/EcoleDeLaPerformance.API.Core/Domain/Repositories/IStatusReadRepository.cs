using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IStatusReadRepository
    {
        Task<List<Status?>> GetStatusesAsync();
    }
}
