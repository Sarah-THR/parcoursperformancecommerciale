using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IContractReadRepository
    {
        Task<List<EcolePerformanceSm>> GetContractByUserNameAsync(string commercial);
        Task<int> GetNbContractByUserNameAsync(string commercial, DateOnly startDate, DateOnly endDate);
        Task<List<VenteOneShot>> GetContractSaleByUserNameAsync(string commercial);
        Task<List<NexleaseContract>> GetContractNexleaseByUserNameAsync(string commercial);
    }
}
