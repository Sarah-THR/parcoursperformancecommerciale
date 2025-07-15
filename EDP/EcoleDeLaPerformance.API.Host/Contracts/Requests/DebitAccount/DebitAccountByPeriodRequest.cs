namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.DebitAccount
{
    public class DebitAccountByPeriodRequest
    {
        public string name { get; set; }
        public DateOnly periodFirstDay { get; set; }
        public DateOnly periodLastDay { get; set; }
    }
}
