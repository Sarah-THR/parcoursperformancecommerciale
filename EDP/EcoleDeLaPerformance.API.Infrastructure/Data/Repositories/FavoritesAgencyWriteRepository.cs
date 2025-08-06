using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class FavoritesAgencyWriteRepository : IFavoritesAgencyWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;
        public FavoritesAgencyWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }
        public async Task<FavoritesAgency> InsertFavoritesAgencyAsync(FavoritesAgency favoritesAgency)
        {
            _parcoursPerformanceCommercialeContext.FavoritesAgencies.Add(favoritesAgency);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return favoritesAgency;
        }
        public async System.Threading.Tasks.Task DeleteFavoritesAgencyAsync(int Id)
        {
            await _parcoursPerformanceCommercialeContext.FavoritesAgencies.Where(p => p.Id == Id).ExecuteDeleteAsync();
        }
        public async System.Threading.Tasks.Task UpdateFavoritesAgencyAsync(FavoritesAgency favoritesAgency)
        {
            _parcoursPerformanceCommercialeContext.FavoritesAgencies.Update(favoritesAgency);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
        }
    }
}
