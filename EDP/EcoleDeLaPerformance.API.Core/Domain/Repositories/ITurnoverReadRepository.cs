namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface ITurnoverReadRepository
    {
        Task<decimal> GetTurnoverByStudentNameAsync(string name, DateTime startDate, DateTime endDate);
        Task<decimal> GetMonthGoalByUserAsync(string name, DateTime goalsDate);
    }
}
