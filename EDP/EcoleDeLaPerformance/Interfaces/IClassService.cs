using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IClassService
    {
        Task<List<Class?>> GetClassesAsync();
        Task CreateDocumentAsync(Document document);
        Task<List<Document>> GetDocumentsAsync();
        Task DeleteDocumentAsync(int documentId);
        Task<Document> UpdateDocumentAsync(Document document);
        Task DownloadDocumentAsync(Document document);
    }
}
