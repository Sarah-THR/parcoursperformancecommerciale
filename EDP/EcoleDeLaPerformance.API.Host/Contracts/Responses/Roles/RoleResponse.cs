namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Roles
{
    public class RoleResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
