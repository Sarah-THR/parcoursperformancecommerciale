using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IPlanningWriteRepository
    {
        Task<Planning> InsertPlanningAsync(Planning planning);
        System.Threading.Tasks.Task DeletePlanningAsync(int planningId);
        System.Threading.Tasks.Task UpdatePlanningAsync(Planning planning);
    }
}
