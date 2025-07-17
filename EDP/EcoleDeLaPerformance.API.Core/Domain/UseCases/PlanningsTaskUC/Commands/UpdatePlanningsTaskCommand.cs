using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningsTaskUC.Commands
{
    public class UpdatePlanningsTaskCommand : IRequest
    {
        public PlanningsTask planningsTask = default!;
    }

    public class UpdatePlanningsTaskCommandHandler : IRequestHandler<UpdatePlanningsTaskCommand>
    {
        private readonly IPlanningsTaskWriteRepository _planningsTaskWriteRepository;

        public UpdatePlanningsTaskCommandHandler(IPlanningsTaskWriteRepository planningsTaskWriteRepository)
        {
            _planningsTaskWriteRepository = planningsTaskWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdatePlanningsTaskCommand command, CancellationToken cancellationToken)
        {
            if (command.planningsTask == null)
                throw new ArgumentNullException("PlanningsTask", "Le planningsTask à modifier est obligatoire.");
            command.planningsTask.UpdatedAt = DateTime.Now;
            await _planningsTaskWriteRepository.UpdatePlanningsTaskAsync(command.planningsTask);
        }
    }
}
