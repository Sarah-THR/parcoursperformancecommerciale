namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Contract
{
    public class GetNbContractsRequest
    {
        public string Commercial { get; set; } = default!;
        public DateOnly StartDate { get; set; } = default!;
        public DateOnly EndDate { get; set; } = default!;
    }
}
