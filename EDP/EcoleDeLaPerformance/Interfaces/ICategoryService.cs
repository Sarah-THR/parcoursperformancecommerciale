using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category?>> GetCategoriesAsync();
    }
}
