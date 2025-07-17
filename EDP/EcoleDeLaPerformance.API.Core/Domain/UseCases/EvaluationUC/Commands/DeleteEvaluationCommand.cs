using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands
{
    public class DeleteEvaluationCommand : IRequest
    {
        public int evaluationId { get; set; }
    }

    public class DeleteEvaluationCommandHandler : IRequestHandler<DeleteEvaluationCommand>
    {
        private readonly IEvaluationWriteRepository _evaluationWriteRepository;

        public DeleteEvaluationCommandHandler(IEvaluationWriteRepository evaluationWriteRepository)
        {
            _evaluationWriteRepository = evaluationWriteRepository;
        }

        public async Task Handle(DeleteEvaluationCommand command, CancellationToken cancellationToken)
        {
            await _evaluationWriteRepository.DeleteEvaluationAsync(command.evaluationId);
        }
    }
}
