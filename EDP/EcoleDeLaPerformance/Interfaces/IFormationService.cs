using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IFormationService
    {
        Task<List<Formation?>> GetFormationsAsync();
        Task<Formation?> InsertFormationAsync(Formation formation);
        System.Threading.Tasks.Task DeleteFormationAsync(int Id);
        System.Threading.Tasks.Task UpdateFormationAsync(Formation formation);
    }
}
