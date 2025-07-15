
using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IWeekWriteRepository
    {
        Task<Week> CreateWeekAsync(Week week);
        System.Threading.Tasks.Task UpdateWeekAsync(Week week);
    }
}
