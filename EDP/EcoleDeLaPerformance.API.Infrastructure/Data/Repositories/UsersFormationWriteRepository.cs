using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class UsersFormationWriteRepository : IUsersFormationWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public UsersFormationWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }
        public async Task<UsersFormation> InsertUsersFormationAsync(UsersFormation usersFormation)
        {
            _parcoursPerformanceCommercialeContext.UsersFormations.Add(usersFormation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return usersFormation;
        }
        public async System.Threading.Tasks.Task UpdateUsersFormationAsync(UsersFormation usersFormation)
        {
            _parcoursPerformanceCommercialeContext.UsersFormations.Update(usersFormation);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
