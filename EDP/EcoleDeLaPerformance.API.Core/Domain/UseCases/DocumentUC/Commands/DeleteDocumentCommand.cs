using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands
{
    public class DeleteDocumentCommand : IRequest
    {
        public int documentId { get; set; }
    }
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IDocumentWriteRepository _documentWriteRepository;

        public DeleteDocumentCommandHandler(IDocumentWriteRepository documentWriteRepository)
        {
            _documentWriteRepository = documentWriteRepository;
        }

        public async Task Handle(DeleteDocumentCommand command, CancellationToken cancellationToken)
        {
            await _documentWriteRepository.DeleteDocumentAsync(command.documentId);
        }
    }
}
