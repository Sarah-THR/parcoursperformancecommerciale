using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Commands
{
    public class UpdateHalfDayPlanningCommand : IRequest
    {
        public HalfDayPlanning halfDayPlanning = default!;
    }

    public class UpdateHalfDayPlanningCommandsHandler : IRequestHandler<UpdateHalfDayPlanningCommand>
    {
        private readonly IHalfDayPlanningWriteRepository _halfDayPlanningWriteRepository;

        public UpdateHalfDayPlanningCommandsHandler(IHalfDayPlanningWriteRepository halfDayPlanningWriteRepository)
        {
            _halfDayPlanningWriteRepository = halfDayPlanningWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateHalfDayPlanningCommand command, CancellationToken cancellationToken)
        {
            if (command.halfDayPlanning == null)
                throw new ArgumentNullException("halfDayPlanning", "Le halfDayPlanning à modifier est obligatoire.");
            await _halfDayPlanningWriteRepository.UpdateHalfDayPlanningAsync(command.halfDayPlanning);
        }
    }
}
