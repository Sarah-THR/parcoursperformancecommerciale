using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands
{
    public class UpdatePlanningCommand : IRequest
    {
        public Planning planning = default!;
    }

    public class UpdatePlanningCommandHandler : IRequestHandler<UpdatePlanningCommand>
    {
        private readonly IPlanningWriteRepository _planningWriteRepository;

        public UpdatePlanningCommandHandler(IPlanningWriteRepository planningWriteRepository)
        {
            _planningWriteRepository = planningWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdatePlanningCommand command, CancellationToken cancellationToken)
        {
            if (command.planning == null)
                throw new ArgumentNullException("Planning", "Le planning à modifier est obligatoire.");
            command.planning.UpdatedAt = DateTime.Now;
            await _planningWriteRepository.UpdatePlanningAsync(command.planning);
        }
    }
}
