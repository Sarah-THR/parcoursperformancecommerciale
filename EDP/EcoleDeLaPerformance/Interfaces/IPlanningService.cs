using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IPlanningService
    {
        Task<Planning?> GetPlanningByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId);
        Task<Planning?> InsertPlanningAsync(Planning planning);
        System.Threading.Tasks.Task DeletePlanningAsync(int Id);
        System.Threading.Tasks.Task UpdatePlanningAsync(Planning planning);
    }
}
