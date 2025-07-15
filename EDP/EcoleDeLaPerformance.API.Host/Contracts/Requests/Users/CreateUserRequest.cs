namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Users
{
    public class CreateUserRequest
    {
        public string EmailAdress { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Entity { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? ProfilePicture { get; set; }

        public string Role { get; set; } = null!;

        public int? Supervisor { get; set; }

        public bool? IsActive { get; set; }
    }
}
