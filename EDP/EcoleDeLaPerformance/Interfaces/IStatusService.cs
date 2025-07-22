using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IStatusService
    {
        Task<List<Status?>> GetStatusesAsync();
    }
}
