using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IBriefService
    {
        Task<List<Brief?>> GetBriefByUserId(DateTime startDateWeek, DateTime endDateWeek, int userId);

        Task<Brief> InsertBriefAsync(Brief brief);

        System.Threading.Tasks.Task UpdateBriefAsync(Brief brief);

        System.Threading.Tasks.Task DeleteBriefAsync(int briefId);

    }
}
