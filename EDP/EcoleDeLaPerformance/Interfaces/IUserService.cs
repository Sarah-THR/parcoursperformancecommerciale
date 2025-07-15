using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User?>> GetUsersAsync();
        Task<List<User?>> GetDeletedUsersAsync();
        Task<List<User?>> GetStudentsAsync();
        Task CreateWeeksForUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<List<User?>> GetAllApprenticesBySupervisorId(int supervisorId);
        Task<decimal> GetStudentBonusAsync(string name, DateOnly startDate, DateOnly endDate);
        Task DeleteUserAsync(int userId);
        User? GetUserAD(string email);
        Task<decimal> GetUserTurnover(string email, DateOnly beginningDate, DateOnly endingDate);

        Task<int> GetNbOpenAccountsAsync(string name);

        int GetNbOpenAccountsByPeriod(string name, DateOnly periodFirstDay, DateOnly periodLastDay);

        Task<int> GetNbAppointmentsAsync(string email, DateOnly beginningDate, DateOnly endingDate);
    }
}
