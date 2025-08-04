using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class RoleReadRepository : IRoleReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public RoleReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<List<Role?>> GetRolesAsync()
        {
            var result = await _parcoursPerformanceCommercialeContext.Roles.ToListAsync();

            return result;
        }
    }
}
