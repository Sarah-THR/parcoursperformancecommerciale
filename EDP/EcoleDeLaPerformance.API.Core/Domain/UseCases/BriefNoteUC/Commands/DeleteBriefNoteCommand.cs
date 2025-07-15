using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands
{
    public class DeleteBriefNoteCommand : IRequest
    {
        public int briefNoteId { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteBriefNoteCommand>
    {
        private readonly IBriefWriteRepository _briefNoteWriteRepository;

        public DeleteCommentCommandHandler(IBriefWriteRepository briefNoteWriteRepository)
        {
            _briefNoteWriteRepository = briefNoteWriteRepository;
        }

        public async Task Handle(DeleteBriefNoteCommand command, CancellationToken cancellationToken)
        {
            await _briefNoteWriteRepository.DeleteBriefNoteAsync(command.briefNoteId);
        }
    }
}
