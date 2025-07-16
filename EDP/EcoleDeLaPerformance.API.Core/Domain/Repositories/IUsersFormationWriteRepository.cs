using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IUsersFormationWriteRepository
    {
        Task<UsersFormation> InsertUsersFormationAsync(UsersFormation usersFormation);
        System.Threading.Tasks.Task UpdateUsersFormationAsync(UsersFormation usersFormation);
    }
}
