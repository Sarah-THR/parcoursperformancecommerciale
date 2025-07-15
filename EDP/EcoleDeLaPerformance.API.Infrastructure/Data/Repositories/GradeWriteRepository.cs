using EcoleDeLaPerformance.API.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class GradeWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public GradeWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Grade> InsertGradeAsync(Grade grade)
        {
            _parcoursPerformanceCommercialeContext.Grades.Add(grade);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return grade;
        }
        public async System.Threading.Tasks.Task DeleteGradeAsync(int gradeId)
        {
            await _parcoursPerformanceCommercialeContext.Grades.Where(p => p.Id == gradeId).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateGradeAsync(Grade grade)
        {
            _parcoursPerformanceCommercialeContext.Grades.Update(grade);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
