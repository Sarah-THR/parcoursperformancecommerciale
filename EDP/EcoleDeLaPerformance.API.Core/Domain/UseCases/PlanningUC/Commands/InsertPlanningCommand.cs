using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands
{
    public class InsertPlanningCommand : IRequest<Planning>
    {
        public Planning planning = default!;

        public class InsertPlanningCommandHandler : IRequestHandler<InsertPlanningCommand, Planning>
        {
            private readonly IPlanningWriteRepository _planningWriteRepository;

            public InsertPlanningCommandHandler(IPlanningWriteRepository planningWriteRepository)
            {
                _planningWriteRepository = planningWriteRepository;
            }

            public async Task<Planning> Handle(InsertPlanningCommand command, CancellationToken cancellationToken)
            {
                if (command.planning == null)
                    throw new ArgumentNullException("Planning", "Le planning à insérer est obligatoire.");

                command.planning.CreatedAt = DateTime.Now;
                return await _planningWriteRepository.InsertPlanningAsync(command.planning);

            }
        }
    }
}
