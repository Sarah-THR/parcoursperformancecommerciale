using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands
{
    public class CreateDocumentCommand : IRequest<Document>
    {
        public Document document { get; set; } = default!;
    }

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
    {
        private readonly IDocumentWriteRepository _documentWriteRepository;

        public CreateDocumentCommandHandler(IDocumentWriteRepository documentWriteRepository)
        {
            _documentWriteRepository = documentWriteRepository;
        }

        public async Task<Document> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
        {
            if (command.document == null)
                throw new ArgumentNullException("Document", "Le document est obligatoire.");

            return await _documentWriteRepository.CreateDocumentAsync(command.document);
        }
    }
}
