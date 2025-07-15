namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Users
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string EmailAdress { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Entity { get; set; } = null!;
        
        public byte[]? ProfilePicture { get; set; }

        public string Role { get; set; } = null!;

        public int? Supervisor { get; set; }

        public bool? IsActive { get; set; }
    }
}
