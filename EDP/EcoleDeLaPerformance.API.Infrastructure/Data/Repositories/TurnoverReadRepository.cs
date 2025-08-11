using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
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
                        _xefiMscrmContext.Accounts.Any(a => a.AccountId == c.CustomerId))
            .Join(_xefiMscrmContext.SystemUsers,
                  c => c.ContractCommercial,
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

        public async Task<decimal> GetMonthGoalByUserAsync(string name, DateTime goalsDate)
        {
            //string connectionString = "Server=XFISRVSQL002; Database=XEFI_MSCRM;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";
            string connectionString = "Server=XFISRVCRM005; Database=XEFI_MSCRM;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery = $"SELECT b.[GoalOwnerId] ,b.[GoalStartDate] ,b.[FiscalYear] ,b.[TargetMoney] ,b.[GoalOwnerIdYomiName] FROM [XEFI_MSCRM].[dbo].[GoalBase] b with (nolock) INNER JOIN [XEFI_MSCRM].[dbo].[SystemUser] su  with (nolock) ON b.GoalOwnerId = su.SystemUserId WHERE MONTH(GoalStartDate) = MONTH('{goalsDate}') AND FiscalYear = YEAR('{goalsDate}') AND b.TargetMoney > 0 AND su.isdisabled = 0 AND b.[GoalOwnerIdYomiName] = '{name}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    decimal monthGoal = new decimal();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            monthGoal = Convert.ToDecimal(reader["TargetMoney"]);
                        }
                    }

                    return monthGoal;
                }
            }
        }
    }

}
