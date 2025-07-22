using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IPlanningsTaskService
    {
        Task<PlanningsTask?> InsertPlanningsTaskAsync(PlanningsTask planningsTask);
        System.Threading.Tasks.Task UpdatePlanningsTaskAsync(PlanningsTask planningsTask);
    }
}
