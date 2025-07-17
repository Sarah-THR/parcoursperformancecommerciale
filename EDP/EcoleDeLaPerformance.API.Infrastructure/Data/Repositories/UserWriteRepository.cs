using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public UserWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<User> InsertUserAsync(User newUser)
        {
            _parcoursPerformanceCommercialeContext.Users.Add(newUser);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return newUser;
        }
        public async Task<User?> UpdateUserAsync(User updatedData)
        {
            var user = await _parcoursPerformanceCommercialeContext.Users.FindAsync(updatedData.Id);
            if (user == null)
            {
                return null;
            }

            user.Name = updatedData.Name;
            user.Email = updatedData.Email;
            user.ProfilePicturePath = updatedData.ProfilePicturePath;
            user.Entity = updatedData.Entity;
            user.StartFollowUp = updatedData.StartFollowUp;
            user.EndFollowUp = updatedData.EndFollowUp;
            user.SupervisorId = updatedData.SupervisorId;
            user.DirectorId = updatedData.DirectorId;
            user.GradeId = updatedData.GradeId;

            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();

            return user;
        }
        public async Task<bool> SoftDeleteUserAsync(int userId)
        {
            var user = await _parcoursPerformanceCommercialeContext.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.DeletedAt = DateTime.Now;
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return true;
        }

    }
}
