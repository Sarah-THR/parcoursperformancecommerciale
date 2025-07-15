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
    public class DeleteHalfDayPlanningCommand : IRequest
    {
        public int halfDayPlanningId { get; set; }
    }

    public class DeleteHalfDayPlanningCommandHandler : IRequestHandler<DeleteHalfDayPlanningCommand>
    {
        private readonly IHalfDayPlanningWriteRepository _halfDayPlanningWriteRepository;

        public DeleteHalfDayPlanningCommandHandler(IHalfDayPlanningWriteRepository halfDayPlanningWriteRepository)
        {
            _halfDayPlanningWriteRepository = halfDayPlanningWriteRepository;
        }

        public async Task Handle(DeleteHalfDayPlanningCommand command, CancellationToken cancellationToken)
        {
            await _halfDayPlanningWriteRepository.DeleteHalfDayPlanningAsync(command.halfDayPlanningId);
        }
    }
}
