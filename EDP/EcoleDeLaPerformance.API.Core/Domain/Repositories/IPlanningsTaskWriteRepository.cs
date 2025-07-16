using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IPlanningsTaskWriteRepository
    {
        Task<PlanningsTask> InsertPlanningsTaskAsync(PlanningsTask planningsTask);
        System.Threading.Tasks.Task UpdatePlanningAsync(PlanningsTask planningsTask);
    }
}
