using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IPlanningReadRepository
    {
        Task<Planning?> GetPlanningByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId);
    }
}
