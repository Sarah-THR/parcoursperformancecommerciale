using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IUserWriteRepository
    {
        Task<User> InsertUserAsync(User newUser);
        Task<User?> UpdateUserAsync(int userId, User updatedData);
        Task<bool> SoftDeleteUserAsync(int userId);
    }
}
