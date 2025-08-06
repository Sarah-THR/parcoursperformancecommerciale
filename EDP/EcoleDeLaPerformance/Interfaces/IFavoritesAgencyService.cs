using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IFavoritesAgencyService
    {
        List<string> GetAgenciesAAD();
        Task<List<FavoritesAgency?>> GetFavoritesAgencyAsync();
        Task<FavoritesAgency?> InsertFavoritesAgencyAsync(FavoritesAgency favoritesAgency);
        System.Threading.Tasks.Task DeleteFavoritesAgencyAsync(int Id);
        System.Threading.Tasks.Task UpdateFavoritesAgencyAsync(FavoritesAgency favoritesAgency);
    }
}
