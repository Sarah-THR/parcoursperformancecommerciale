using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IUsersFormationService
    {
        Task<UsersFormation?> InsertUsersFormationAsync(UsersFormation usersFormation);
        System.Threading.Tasks.Task UpdateUsersFormationAsync(UsersFormation usersFormation);
    }
}
