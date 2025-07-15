using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands
{
    public class InsertBriefNoteCommand : IRequest<BriefNote>
    {
        public BriefNote briefNote = default!;

        public class CreateNotificationCommandHandler : IRequestHandler<InsertBriefNoteCommand, BriefNote>
        {
            private readonly IBriefWriteRepository _briefNoteWriteRepository;

            public CreateNotificationCommandHandler(IBriefWriteRepository briefNoteWriteRepository)
            {
                _briefNoteWriteRepository = briefNoteWriteRepository;
            }

            public async Task<BriefNote> Handle(InsertBriefNoteCommand command, CancellationToken cancellationToken)
            {
                if (command.briefNote == null)
                    throw new ArgumentNullException("briefnote", "La briefnote à insérer est obligatoire.");

                command.briefNote.CreatedAt =DateTime.Now;
                return await _briefNoteWriteRepository.InsertBriefNoteAsync(command.briefNote);

            }
        }
    }
}
