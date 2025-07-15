using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IDebriefReadRepository
    {
        Task<List<Debrief?>> GetDebriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId);
    }
}
