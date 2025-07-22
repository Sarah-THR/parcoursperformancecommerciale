using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade?>> GetGradesAsync();
        Task<Grade?> InsertGradeAsync(Grade grade);
        System.Threading.Tasks.Task DeleteGradeAsync(int Id);
        System.Threading.Tasks.Task UpdateGradeAsync(Grade grade);
    }
}
