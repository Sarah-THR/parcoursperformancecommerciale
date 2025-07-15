using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{

    public class TurnoverReadRepository: ITurnoverReadRepository
    {
        private readonly XefiMscrmContext _xefiMscrmContext;

        public TurnoverReadRepository(XefiMscrmContext xefiMscrmContext)
        {
            _xefiMscrmContext = xefiMscrmContext;
        }

        public async Task<decimal> GetTurnoverByStudentNameAsync(string name, DateTime startDate, DateTime endDate)
        {
            decimal result = 0;

            decimal? turnover = _xefiMscrmContext.Contracts
            .Where(c => c.CreatedOn.Value.Date >= startDate.Date &&
                        c.CreatedOn.Value.Date <= endDate.Date &&
                        _xefiMscrmContext.Accounts.Any(a => a.AccountId == c.CustomerId &&
                                                      a.CreatedOn.Value.Date == c.CreatedOn.Value.Date))
            .Join(_xefiMscrmContext.SystemUsers,
                  c => c.CreatedBy,
                  u => u.SystemUserId,
                  (c, u) => new { Contract = c, User = u })
            .Where(join => join.User.FullName == name)
            .Select(join => join.Contract.TotalPrice)
            .FirstOrDefault();

            if (turnover != null)
            {
                result = (decimal)turnover;
            }
            return result;
        }
    }

}
