using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface ITaskPlanningService
    {
        Task<List<TaskPlanning?>> GetAllTaskPlanning();

    }
}
