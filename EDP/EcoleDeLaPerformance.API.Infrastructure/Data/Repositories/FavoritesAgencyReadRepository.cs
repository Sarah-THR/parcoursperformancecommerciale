using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class FavoritesAgencyReadRepository: IFavoritesAgencyReadRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public FavoritesAgencyReadRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<List<FavoritesAgency?>> GetFavoritesAgenciesAsync()
        {
            return await _parcoursPerformanceCommercialeContext.FavoritesAgencies.ToListAsync();
        }
    }
}
