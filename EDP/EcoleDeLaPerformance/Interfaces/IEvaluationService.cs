using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IEvaluationService
    {
        Task<List<Evaluation?>> GetEvaluationsAsync();
        Task<Evaluation?> InsertEvaluationAsync(Evaluation evaluation);
        System.Threading.Tasks.Task DeleteEvaluationAsync(int Id);
        System.Threading.Tasks.Task UpdateEvaluationAsync(Evaluation evaluation);
    }
}
