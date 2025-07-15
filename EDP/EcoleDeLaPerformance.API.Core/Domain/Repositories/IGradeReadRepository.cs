using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IGradeReadRepository
    {
        Task<List<Grade?>> GetGradesAsync();
    }
}
