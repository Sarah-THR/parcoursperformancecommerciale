using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IUserReadRepository
    {
        Task<User?> GetUserByEmailAsync(string userEmail);
        Task<User?> GetUserByIdAsync(int userId);
        Task<List<User>> GetUsersAsync();
    }
}
