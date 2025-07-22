using EcoleDeLaPerformance.Ui.Models;
using EcoleDeLaPerformance.Ui.Models.BI;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IContractService
    {
        List<EcolePerformanceSm?> GetContractsByUserName(string commercial);

        List<EcolePerformanceSm?> GetContractsByPeriod(string commercial, DateOnly firstDay, DateOnly lastDay);

        int GetNbContractsByUser(string commercial, DateOnly startDate, DateOnly endDate);

        int GetNbContractsSaleByUser(string commercial, DateOnly startDate, DateOnly endDate);

        int GetNbContractsNexleaseByUser(string commercial, DateOnly startDate, DateOnly endDate);
    }
}
