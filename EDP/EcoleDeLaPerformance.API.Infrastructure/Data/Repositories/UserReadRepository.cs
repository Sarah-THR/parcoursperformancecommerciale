using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public UserReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }
        public async Task<User?> GetUserByEmailAsync(string userEmail)
        {
            return await _parcoursPerformanceCommercialeContext.Users
                   .Include(u => u.Role)
                   .Include(u => u.Grade)
                   .Include(u => u.Supervisor)
                   .Include(u => u.Director)
                   .Include(u => u.UsersFormations)
                       .ThenInclude(uf => uf.Formation)
                   .Include(u => u.UsersFormations)
                       .ThenInclude(uf => uf.Evaluation)
                   .Include(u => u.UsersFormations)
                       .ThenInclude(uf => uf.Document)
                   .Include(u => u.Plannings)
                       .ThenInclude(x => x.PlanningsTasks)
                       .ThenInclude(x => x.Task)
                   .FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _parcoursPerformanceCommercialeContext.Users
                .Include(u => u.Grade)
                .Include(u => u.Role)
                .Include(u => u.Supervisor)
                .Include(u => u.Director)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Formation)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Evaluation)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Document)
                .Include(u => u.Plannings)
                    .ThenInclude(x => x.PlanningsTasks)
                    .ThenInclude(x => x.Task)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _parcoursPerformanceCommercialeContext.Users
                .Include(u => u.Grade)
                .Include(u => u.Role)
                .Include(u => u.Supervisor)
                .Include(u => u.Director)
                .Include(u => u.Plannings)
                    .ThenInclude(x => x.PlanningsTasks)
                    .ThenInclude(x => x.Task)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Formation)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Evaluation)
                .Include(u => u.UsersFormations)
                    .ThenInclude(uf => uf.Document)
                .ToListAsync();
        }
    }
}
