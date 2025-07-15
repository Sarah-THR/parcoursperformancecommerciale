using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Requests
{
    public class GetDocumentsRequest : IRequest<IEnumerable<Document>>
    {
    }
    public class GetDocumentsRequestHandler : IRequestHandler<GetDocumentsRequest, IEnumerable<Document>>
    {
        private readonly IDocumentReadRepository _documentReadRepository;

        public GetDocumentsRequestHandler(IDocumentReadRepository documentReadRepository)
        {
            _documentReadRepository = documentReadRepository;
        }

        public async Task<IEnumerable<Document>> Handle(GetDocumentsRequest request, CancellationToken cancellationToken)
        {
            return await _documentReadRepository.GetDocumentsAsync();
        }
    }
}
