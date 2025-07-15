using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.TurnoverUC.Requests
{
    public class GetTurnoverByStudentNameRequest : IRequest<decimal>
    {
        public string name { get; set; } 
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class GetTurnoverByStudentNameRequestHandler : IRequestHandler<GetTurnoverByStudentNameRequest, decimal>
    {
        private readonly ITurnoverReadRepository _turnoverReadRepository;

        public GetTurnoverByStudentNameRequestHandler(ITurnoverReadRepository turnoverReadRepository)
        {
            _turnoverReadRepository = turnoverReadRepository;
        }

        public async Task<decimal> Handle(GetTurnoverByStudentNameRequest request, CancellationToken cancellationToken)
        {
            return await _turnoverReadRepository.GetTurnoverByStudentNameAsync(request.name, request.startDate, request.endDate);
        }
    }
}
