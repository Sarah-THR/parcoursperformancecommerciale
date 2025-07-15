using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands
{
    public class UpdateBriefNoteCommand : IRequest
    {
        public BriefNote briefNote = default!;
    }

    public class UpdateBriefNoteCommandsHandler : IRequestHandler<UpdateBriefNoteCommand>
    {
        private readonly IBriefWriteRepository _briefNoteWriteRepository;

        public UpdateBriefNoteCommandsHandler(IBriefWriteRepository briefNoteWriteRepository)
        {
            _briefNoteWriteRepository = briefNoteWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateBriefNoteCommand command, CancellationToken cancellationToken)
        {
            if (command.briefNote == null)
                throw new ArgumentNullException("BriefNote", "La briefnote à modifier est obligatoire.");
            command.briefNote.UpdatedAt = DateTime.Now;
            await _briefNoteWriteRepository.UpdateBriefNoteAsync(command.briefNote);
        }
    }
}
