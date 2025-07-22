using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IDebriefService
    {
        Task<List<Debrief?>> GetDebriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId);
        Task<Debrief?> InsertDebriefAsync(Debrief debrief);
        System.Threading.Tasks.Task DeleteDebriefAsync(int debriefId);
        System.Threading.Tasks.Task UpdateDebriefAsync(Debrief debrief);
    }
}
