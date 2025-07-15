using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class DebitAccountReadRepository : IDebitAccountReadRepository
    {
        private readonly XefiMscrmContext _xefiMscrmContext;
        private readonly BiContext _biContext;

        public DebitAccountReadRepository(XefiMscrmContext xefiMscrmContext, BiContext biContext)
        {
            _xefiMscrmContext = xefiMscrmContext;
            _biContext = biContext;
        }

        public async Task<int> GetDebitAccountByCommercialNameAsync(string name)
        {
            var fcQuery = _biContext.FicheCrms.Where(fc => fc.Commercial == name);
            var abQuery = _xefiMscrmContext.Accounts.Where(ab => ab.XefiMoyendepaiement == 7);

            var fcList = await fcQuery.ToListAsync();
            var abList = await abQuery.ToListAsync();

            var result = (
                from fc in fcList
                join ab in abList on fc.Accountid equals ab.AccountId
                group ab by fc.Commercial into g
                select new
                {
                    Commercial = g.Key,
                    NbrDebitAccount = g.Count()
                }
            ).FirstOrDefault();

            return result?.NbrDebitAccount ?? 0;
        }

        public async Task<int> GetDebitAccountByPeriodAsync(string name, DateOnly periodFirstDay, DateOnly periodLastDay)
        {
            var fcQuery = _biContext.FicheCrms.Where(fc => fc.Commercial == name);
            var abQuery = _xefiMscrmContext.Accounts.Where(ab => ab.XefiMoyendepaiement == 7 && DateOnly.FromDateTime((DateTime)ab.CreatedOn) >= periodFirstDay && DateOnly.FromDateTime((DateTime)ab.CreatedOn) <= periodLastDay);

            var fcList = await fcQuery.ToListAsync();
            var abList = await abQuery.ToListAsync();

            var result = (
                from fc in fcList
                join ab in abList on fc.Accountid equals ab.AccountId
                group ab by fc.Commercial into g
                select new
                {
                    Commercial = g.Key,
                    NbrDebitAccount = g.Count()
                }
            ).FirstOrDefault();

            return result?.NbrDebitAccount ?? 0;
        }
    }
}
