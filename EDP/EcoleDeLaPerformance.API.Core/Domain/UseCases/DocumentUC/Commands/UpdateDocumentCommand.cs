using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands
{
    public class UpdateDocumentCommand : IRequest<Document>
    {
        public Document document = default!;
    }

    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, Document>
    {
        private readonly IDocumentReadRepository _documentReadRepository;
        private readonly IDocumentWriteRepository _documentWriteRepository;

        public UpdateDocumentCommandHandler(IDocumentReadRepository documentReadRepository, IDocumentWriteRepository documentWriteRepository)
        {
            _documentReadRepository = documentReadRepository;
            _documentWriteRepository = documentWriteRepository;
        }

        public async Task<Document> Handle(UpdateDocumentCommand command, CancellationToken cancellationToken)
        {
            if (command.document == null)
                throw new ArgumentNullException("Document", "Le document à modifier est obligatoire.");
            var allDocuments = await _documentReadRepository.GetDocumentsAsync();
            var document = allDocuments.ToList().Where(x => x.Id == command.document.Id).First()
                ?? throw new ArgumentException($"Le document avec l'id {command.document.Id} n'existe pas.");

            document.Title = command.document.Title;
            document.ClassId = command.document.ClassId;
            document.File = command.document.File;
            document.UpdatedAt = command.document.UpdatedAt;
            document.UpdatedBy = command.document.UpdatedBy;
            return await _documentWriteRepository.UpdateDocumentAsync(document);
        }
    }
}
