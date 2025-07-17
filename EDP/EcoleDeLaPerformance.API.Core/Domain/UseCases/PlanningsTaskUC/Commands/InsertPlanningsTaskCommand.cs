using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningsTaskUC.Commands
{
    public class InsertPlanningsTaskCommand : IRequest<PlanningsTask>
    {
        public PlanningsTask planningsTask = default!;

        public class InsertPlanningsTaskCommandHandler : IRequestHandler<InsertPlanningsTaskCommand, PlanningsTask>
        {
            private readonly IPlanningsTaskWriteRepository _planningsTaskWriteRepository;

            public InsertPlanningsTaskCommandHandler(IPlanningsTaskWriteRepository planningsTaskWriteRepository)
            {
                _planningsTaskWriteRepository = planningsTaskWriteRepository;
            }

            public async Task<PlanningsTask> Handle(InsertPlanningsTaskCommand command, CancellationToken cancellationToken)
            {
                if (command.planningsTask == null)
                    throw new ArgumentNullException("PlanningsTask", "Le planningsTask à insérer est obligatoire.");

                command.planningsTask.CreatedAt = DateTime.Now;
                return await _planningsTaskWriteRepository.InsertPlanningsTaskAsync(command.planningsTask);

            }
        }
    }
}
