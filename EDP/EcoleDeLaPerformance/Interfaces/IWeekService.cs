using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IWeekService
    {
        Task<List<Week?>> GetWeeksByUserIdAsync(int userId);
        Task<Week> CreateWeekAsync(Week week);
        Task<List<Week?>> GetWeeksByIdAsync(int weekId);
        Task UpdateWeekAsync(Week week);
    }
}
