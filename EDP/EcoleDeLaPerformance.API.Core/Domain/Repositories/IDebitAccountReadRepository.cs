using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IDebitAccountReadRepository
    {
        Task<int> GetDebitAccountByCommercialNameAsync(string name);
        Task<int> GetDebitAccountByPeriodAsync(string name, DateOnly periodFirstDay, DateOnly periodLastDay);
    }
}
