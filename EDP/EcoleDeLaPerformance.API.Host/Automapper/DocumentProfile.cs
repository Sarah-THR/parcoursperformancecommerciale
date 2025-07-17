using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Document;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentResponse>();
            CreateMap<DocumentRequest, Document>();
            CreateMap<CreateDocumentRequest, Document>();
            CreateMap<UpdateDocumentRequest, Document>();
        }
    }
}
