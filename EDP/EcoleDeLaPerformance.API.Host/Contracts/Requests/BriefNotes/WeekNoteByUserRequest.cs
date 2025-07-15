namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes
{
    public class WeekNoteByUserRequest
    {
        public DateTime StartDateWeek { get; set; }
        public DateTime EndDateWeek { get; set; }
        public int UserId { get; set; }

    }
}
