namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts
{
    public class ContractSmsResponse
    {
        public DateOnly? DateSignature { get; set; }

        public string? Maintenance { get; set; }

        public string? Sauvegarde { get; set; }

        public string? Sécurité { get; set; }

        public string? Commercial { get; set; }
    }
}
