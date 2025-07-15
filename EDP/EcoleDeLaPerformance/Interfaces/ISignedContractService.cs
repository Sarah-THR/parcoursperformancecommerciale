using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface ISignedContractService
    {
        Task<List<SignedContract?>> GetSignedContractByWeekId(int weekId);

    }
}
