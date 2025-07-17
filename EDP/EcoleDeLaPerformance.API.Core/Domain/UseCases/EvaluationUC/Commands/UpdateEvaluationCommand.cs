using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands
{
    public class UpdateEvaluationCommand : IRequest
    {
        public Evaluation evaluation = default!;
    }

    public class UpdateEvaluationCommandHandler : IRequestHandler<UpdateEvaluationCommand>
    {
        private readonly IEvaluationWriteRepository _evaluationWriteRepository;

        public UpdateEvaluationCommandHandler(IEvaluationWriteRepository evaluationWriteRepository)
        {
            _evaluationWriteRepository = evaluationWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateEvaluationCommand command, CancellationToken cancellationToken)
        {
            if (command.evaluation == null)
                throw new ArgumentNullException("Evaluation", "L'evaluation à modifier est obligatoire.");
            command.evaluation.UpdatedAt = DateTime.Now;
            await _evaluationWriteRepository.UpdateEvaluationAsync(command.evaluation);
        }
    }
}
