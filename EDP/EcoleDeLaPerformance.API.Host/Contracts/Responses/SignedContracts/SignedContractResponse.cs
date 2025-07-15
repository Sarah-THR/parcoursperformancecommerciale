using EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks;
using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.SignedContracts
{
    public class SignedContractResponse
    {
        public int SignedContractId { get; set; }

        public int TypeContract { get; set; }

        public int WeekId { get; set; }

        public virtual WeekResponse Week { get; set; } = null!;
    }
}
