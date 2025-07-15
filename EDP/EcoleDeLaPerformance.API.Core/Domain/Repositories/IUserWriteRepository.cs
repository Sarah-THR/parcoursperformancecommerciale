using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IUserWriteRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int userId);
    }
}
