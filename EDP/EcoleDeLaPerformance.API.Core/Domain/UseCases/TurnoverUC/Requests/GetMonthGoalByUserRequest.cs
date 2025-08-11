using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.TurnoverUC.Requests
{
    public class GetMonthGoalByUserRequest : IRequest<decimal>
    {
        public string name { get; set; }
        public DateTime goalsDate { get; set; }
    }

    public class GetMonthGoalByUserRequestHandler : IRequestHandler<GetMonthGoalByUserRequest, decimal>
    {
        private readonly ITurnoverReadRepository _turnoverReadRepository;

        public GetMonthGoalByUserRequestHandler(ITurnoverReadRepository turnoverReadRepository)
        {
            _turnoverReadRepository = turnoverReadRepository;
        }

        public async Task<decimal> Handle(GetMonthGoalByUserRequest request, CancellationToken cancellationToken)
        {
            return await _turnoverReadRepository.GetMonthGoalByUserAsync(request.name, request.goalsDate);
        }
    }
}
