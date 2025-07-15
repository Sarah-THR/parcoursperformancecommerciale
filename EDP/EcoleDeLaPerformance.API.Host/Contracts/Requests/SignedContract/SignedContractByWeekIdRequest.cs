using MediatR;

namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.SignedContract
{
    public class SignedContractByWeekIdRequest
    {
        public int weekId { get; set; }
    }
}
