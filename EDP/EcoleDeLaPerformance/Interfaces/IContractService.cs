using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IContractService
    {
        List<SignedContract?> GetContractsByUserName(string commercial);

        List<SignedContract?> GetContractsByPeriod(string commercial, DateOnly firstDay, DateOnly lastDay);

        int GetNbContractsByUser(string commercial, DateOnly startDate, DateOnly endDate);

        int GetNbContractsSaleByUser(string commercial, DateOnly startDate, DateOnly endDate);

        int GetNbContractsNexleaseByUser(string commercial, DateOnly startDate, DateOnly endDate);
    }
}
