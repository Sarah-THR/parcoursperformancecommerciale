using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Requests
{
    public class GetEvaluationRequest : IRequest<IEnumerable<Evaluation>>
    {
    }

    public class GetEvaluationRequestHandler : IRequestHandler<GetEvaluationRequest, IEnumerable<Evaluation>>
    {
        private readonly IEvaluationReadRepository _evaluationReadRepository;

        public GetEvaluationRequestHandler(IEvaluationReadRepository evaluationReadRepository)
        {
            _evaluationReadRepository = evaluationReadRepository;
        }

        public async Task<IEnumerable<Evaluation>> Handle(GetEvaluationRequest request, CancellationToken cancellationToken)
        {
            return await _evaluationReadRepository.GetEvaluationsAsync();
        }
    }
}
