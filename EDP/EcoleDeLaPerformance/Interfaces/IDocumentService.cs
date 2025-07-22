using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface IDocumentService
    {
        Task<List<Document>> GetDocuments();
        Task<Document> CreateDocumentAsync(Document document);
        System.Threading.Tasks.Task UpdateDocumentAsync(Document document);
        System.Threading.Tasks.Task DeleteDocumentAsync(int id);
    }
}
