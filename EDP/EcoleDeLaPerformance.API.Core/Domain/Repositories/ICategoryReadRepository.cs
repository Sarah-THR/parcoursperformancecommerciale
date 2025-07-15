using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface ICategoryReadRepository
    {
        Task<List<Category?>> GetCategoriesAsync();
    }
}
