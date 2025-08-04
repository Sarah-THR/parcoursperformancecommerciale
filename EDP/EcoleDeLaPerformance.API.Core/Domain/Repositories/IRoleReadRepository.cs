using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IRoleReadRepository
    {
        Task<List<Role?>> GetRolesAsync();
    }
}
