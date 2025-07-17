using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands
{
    public class DeletePlanningCommand : IRequest
    {
        public int planningId { get; set; }
    }

    public class DeletePlanningCommandHandler : IRequestHandler<DeletePlanningCommand>
    {
        private readonly IPlanningWriteRepository _planningWriteRepository;

        public DeletePlanningCommandHandler(IPlanningWriteRepository planningWriteRepository)
        {
            _planningWriteRepository = planningWriteRepository;
        }

        public async Task Handle(DeletePlanningCommand command, CancellationToken cancellationToken)
        {
            await _planningWriteRepository.DeletePlanningAsync(command.planningId);
        }
    }
}
