using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IBriefNoteService
    {
        Task<List<BriefNote?>> GetWeekNoteByUserId(DateTime startDateWeek, DateTime endDateWeek, int userId);

        Task<BriefNote> InsertBriefNoteAsync(BriefNote briefNote);

        Task UpdateBriefNoteAsync(BriefNote briefNote);

        Task DeleteBriefNoteAsync(int briefNoteId);

    }
}
