using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role?>> GetRolesAsync();
    }
}
