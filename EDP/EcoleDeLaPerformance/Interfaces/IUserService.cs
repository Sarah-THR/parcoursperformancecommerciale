using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IUserService
    {
        Task<List<User?>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<User?> InsertUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int Id);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        Task<decimal> GetUserBonusAsync(string name, DateOnly startDate, DateOnly endDate);
        Task<decimal> GetUserTurnoverAsync(string email, DateOnly beginningDate, DateOnly endingDate);
        Task<decimal> GetUserMonthGoalAsync(string name, DateOnly monthDate);
        //Task<int> GetNbOpenAccountsAsync(string name);

        //int GetNbOpenAccountsByPeriod(string name, DateOnly periodFirstDay, DateOnly periodLastDay);
        User? GetUserAAD(string email);
        Task<int> GetNbAppointmentsAsync(string email, DateOnly beginningDate, DateOnly endingDate);
    }
}
