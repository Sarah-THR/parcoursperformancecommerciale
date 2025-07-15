using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IWeekReadRepository
    {
        Task<IEnumerable<Week>> GetWeeksByUserIdAsync(int userId);
    }
}
