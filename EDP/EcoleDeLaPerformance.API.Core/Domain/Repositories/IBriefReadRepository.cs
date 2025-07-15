using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IBriefReadRepository
    {
        Task<List<Brief?>> GetBriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId);
    }
}
