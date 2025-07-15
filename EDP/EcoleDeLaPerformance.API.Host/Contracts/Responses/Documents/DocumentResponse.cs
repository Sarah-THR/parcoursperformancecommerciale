using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Classes;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents
{
    public class DocumentResponse
    {
        public int DocumentId { get; set; }

        public string Pdffile { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? CreateBy { get; set; }

        public int? UpdateBy { get; set; }

        public int ClassId { get; set; }

        public virtual UserResponse? CreateByNavigation { get; set; }

        public virtual UserResponse? UpdateByNavigation { get; set; } = null!;
        public virtual DocumentClassResponse Class { get; set; }
    }
}
