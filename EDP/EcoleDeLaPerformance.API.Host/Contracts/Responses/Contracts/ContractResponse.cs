namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts
{
    public class ContractResponse
    {
        public string? ContractNumber { get; set; }

        public DateOnly? DateContrat { get; set; }

        public string? Agence { get; set; }

        public string? Commercial { get; set; }
    }
}
