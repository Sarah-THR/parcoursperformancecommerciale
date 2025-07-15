using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public UserReadRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _ecoleDeLaPerformancePreprodContext.Users
                .Include(x => x.Weeks.OrderBy(o => o.WeekNumber))
                 .ThenInclude(o => o.HalfDayPlannings)
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int UserId)
        {
            var user = await _ecoleDeLaPerformancePreprodContext.Users
                 .Include(x => x.Weeks.OrderBy(o => o.WeekNumber))
                 .ThenInclude(o => o.HalfDayPlannings)
                 .FirstOrDefaultAsync(u => u.Id == UserId);
            user.Supervisor = _ecoleDeLaPerformancePreprodContext.Users.Where(x => x.Id == user.SupervisorId).FirstOrDefault();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _ecoleDeLaPerformancePreprodContext.Users
                 .Include(x => x.Weeks.OrderBy(o => o.WeekNumber))
                 .ThenInclude(o => o.HalfDayPlannings)
                .FirstOrDefaultAsync(u => string.Equals(u.Email, email));
            user.Supervisor = _ecoleDeLaPerformancePreprodContext.Users.Where(x => x.Id == user.SupervisorId).FirstOrDefault();
            return user;
        }
    }
}
