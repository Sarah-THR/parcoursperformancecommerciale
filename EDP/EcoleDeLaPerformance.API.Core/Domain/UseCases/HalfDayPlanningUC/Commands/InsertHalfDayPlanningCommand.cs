using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Commands
{
    public class InsertHalfDayPlanningCommand : IRequest<HalfDayPlanning>
    {
        public HalfDayPlanning halfDayPlanning = default!;

        public class InsertHalfDayPlanningCommandHandler : IRequestHandler<InsertHalfDayPlanningCommand,HalfDayPlanning>
        {
            private readonly IHalfDayPlanningWriteRepository _halfDayPlanningWriteRepository;

            public InsertHalfDayPlanningCommandHandler(IHalfDayPlanningWriteRepository halfDayPlanningWriteRepository)
            {
                _halfDayPlanningWriteRepository = halfDayPlanningWriteRepository;
            }

            public async Task<HalfDayPlanning> Handle(InsertHalfDayPlanningCommand command, CancellationToken cancellationToken)
            {
                if (command.halfDayPlanning == null)
                    throw new ArgumentNullException("halfDayPlanning", "Le halfdayplanning à insérer est obligatoire.");

                return await _halfDayPlanningWriteRepository.InsertHalfDayPlanningAsync(command.halfDayPlanning);

            }
        }
    }
}
