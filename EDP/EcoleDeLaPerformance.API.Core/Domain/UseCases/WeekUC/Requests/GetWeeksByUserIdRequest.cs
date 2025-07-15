using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Requests
{
    public class GetWeeksByUserIdRequest : IRequest<IEnumerable<Week>>
    {
        public int userId { get; set; }
    }

    public class GetWeeksByUserIdRequestHandler : IRequestHandler<GetWeeksByUserIdRequest, IEnumerable<Week>>
    {
        private readonly IWeekReadRepository _weekReadRepository;

        public GetWeeksByUserIdRequestHandler(IWeekReadRepository weekReadRepository)
        {
            _weekReadRepository = weekReadRepository;
        }

        public async Task<IEnumerable<Week>> Handle(GetWeeksByUserIdRequest request, CancellationToken cancellationToken)
        {
            return await _weekReadRepository.GetWeeksByUserIdAsync(request.userId);
        }
    }
}
