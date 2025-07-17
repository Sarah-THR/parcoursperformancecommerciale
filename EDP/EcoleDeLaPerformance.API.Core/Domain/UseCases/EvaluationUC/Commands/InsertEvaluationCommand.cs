using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands
{
    public class InsertEvaluationCommand : IRequest<Evaluation>
    {
        public Evaluation evaluation = default!;

        public class InsertEvaluationCommandHandler : IRequestHandler<InsertEvaluationCommand, Evaluation>
        {
            private readonly IEvaluationWriteRepository _evaluationWriteRepository;

            public InsertEvaluationCommandHandler(IEvaluationWriteRepository evaluationWriteRepository)
            {
                _evaluationWriteRepository = evaluationWriteRepository;
            }

            public async Task<Evaluation> Handle(InsertEvaluationCommand command, CancellationToken cancellationToken)
            {
                if (command.evaluation == null)
                    throw new ArgumentNullException("evaluation", "L'evaluation à insérer est obligatoire.");

                command.evaluation.CreatedAt = DateTime.Now;
                return await _evaluationWriteRepository.InsertEvaluationAsync(command.evaluation);

            }
        }
    }
}
