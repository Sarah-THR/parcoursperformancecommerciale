using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IDocumentWriteRepository
    {
        Task<Document> CreateDocumentAsync(Document document);
        Task<Document> UpdateDocumentAsync(Document document);
        System.Threading.Tasks.Task DeleteDocumentAsync(int documentId);
    }
}
