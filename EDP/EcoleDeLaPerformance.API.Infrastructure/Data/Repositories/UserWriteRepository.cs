using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public UserWriteRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            User userExist = _ecoleDeLaPerformancePreprodContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (userExist == null)
            {
                _ecoleDeLaPerformancePreprodContext.Add(user);
                await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
                return user;
            }
            else
            {
                userExist.IsActive = true;
                return await UpdateUserAsync(userExist);
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _ecoleDeLaPerformancePreprodContext.Update(user);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
            return user;
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int userId)
        {
            //var documentsById = await _ecoleDeLaPerformancePreprodContext.Documents.Where(x => x.CreateBy == userId).ToListAsync();
            //foreach (var document in documentsById)
            //{
            //    document.CreateBy = null;
            //    document.UpdateBy = null;
            //    _ecoleDeLaPerformancePreprodContext.Update(document);
            //    await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
            //}

            var studentsById = await _ecoleDeLaPerformancePreprodContext.Users.Where(x => x.SupervisorId == userId).ToListAsync();
            foreach (var student in studentsById)
            {
                student.Supervisor = null;
                _ecoleDeLaPerformancePreprodContext.Update(student);
                await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
            }

            var userToDelete = _ecoleDeLaPerformancePreprodContext.Users
                .Include(x => x.Weeks.OrderBy(o => o.WeekNumber))
                 .ThenInclude(o => o.HalfDayPlannings)
                 .Where(x => x.Id == userId)
                 .First();
            if (userToDelete.IsActive == true)
            {
                userToDelete.IsActive = false;
            }
            else
            {
                userToDelete.IsActive = true;
            }
            _ecoleDeLaPerformancePreprodContext.Update(userToDelete);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
        }
    }
}
