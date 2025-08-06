using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IFavoritesAgencyWriteRepository
    {
        Task<FavoritesAgency> InsertFavoritesAgencyAsync(FavoritesAgency favoritesAgency);
        System.Threading.Tasks.Task DeleteFavoritesAgencyAsync(int Id);
        System.Threading.Tasks.Task UpdateFavoritesAgencyAsync(FavoritesAgency favoritesAgency);
    }
}
