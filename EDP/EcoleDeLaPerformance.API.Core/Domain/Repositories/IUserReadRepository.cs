using EcoleDeLaPerformance.API.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IUserReadRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int UserId);

        Task<User?> GetUserByEmailAsync(string email);
    }
}
