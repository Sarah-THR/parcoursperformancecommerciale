namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Turnover
{
    public class TurnoverByStudentNameRequest
    {
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
