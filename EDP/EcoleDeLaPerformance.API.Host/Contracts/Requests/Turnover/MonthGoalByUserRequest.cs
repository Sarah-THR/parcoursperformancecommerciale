namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Turnover
{
    public class MonthGoalByUserRequest
    {
        public string name { get; set; }
        public DateTime goalsDate { get; set; }
    }
}
