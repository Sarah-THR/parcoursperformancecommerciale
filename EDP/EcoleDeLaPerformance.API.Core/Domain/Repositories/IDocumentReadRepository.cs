using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IDocumentReadRepository
    {
        Task<IEnumerable<Document>> GetDocumentsAsync();
    }
}
