using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class DocumentWriteRepository : IDocumentWriteRepository
    {
        private readonly ParcoursPerformanceCommercialeContext _parcoursPerformanceCommercialeContext;

        public DocumentWriteRepository(ParcoursPerformanceCommercialeContext parcoursPerformanceCommercialeContext)
        {
            _parcoursPerformanceCommercialeContext = parcoursPerformanceCommercialeContext;
        }

        public async Task<Document> CreateDocumentAsync(Document document)
        {
            var existingDocument = await _parcoursPerformanceCommercialeContext.Documents.FindAsync(document.Id);
            if (existingDocument != null)
            {
                existingDocument.ContentPath += document.ContentPath; 
                existingDocument.Title = document.Title;
                existingDocument.UpdatedAt = document.UpdatedAt;
            }
            else
            {
                _parcoursPerformanceCommercialeContext.Documents.Add(document);
            }
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateDocumentAsync(Document document)
        {
            _parcoursPerformanceCommercialeContext.Update(document);
            await _parcoursPerformanceCommercialeContext.SaveChangesAsync();
            return document;
        }

        public async System.Threading.Tasks.Task DeleteDocumentAsync(int documentId)
        {
            await _parcoursPerformanceCommercialeContext.Documents.Where(p => p.Id == documentId).ExecuteDeleteAsync();
        }
    }
}
