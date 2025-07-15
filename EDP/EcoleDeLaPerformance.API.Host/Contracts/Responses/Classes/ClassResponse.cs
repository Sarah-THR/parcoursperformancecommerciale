using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Classes
{
    public class ClassResponse
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; } = null!;

        public virtual ICollection<DocumentResponse> Documents { get; set; } = new List<DocumentResponse>();
    }
}
