using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IGradeWriteRepository
    {
        Task<Grade> InsertGradeAsync(Grade grade);
        System.Threading.Tasks.Task DeleteGradeAsync(int gradeId);
        System.Threading.Tasks.Task UpdateGradeAsync(Grade grade);
    }
}
