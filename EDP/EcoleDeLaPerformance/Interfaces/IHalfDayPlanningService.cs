using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IHalfDayPlanningService
    {
        Task<List<HalfDayPlanning?>> GetHalfDayPlanningsByWeekIdAsync(int weekId);
        Task<HalfDayPlanning> InsertHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning);
        Task UpdateHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning);
        Task DeleteHalfDayPlanningAsync(int halfDayPlanningId);

    }
}
