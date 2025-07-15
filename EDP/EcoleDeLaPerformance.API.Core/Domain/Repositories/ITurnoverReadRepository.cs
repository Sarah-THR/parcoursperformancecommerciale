namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface ITurnoverReadRepository
    {
        Task<decimal> GetTurnoverByStudentNameAsync(string name, DateTime startDate, DateTime endDate);
    }
}
