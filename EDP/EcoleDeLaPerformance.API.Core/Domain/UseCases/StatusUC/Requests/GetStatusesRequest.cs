using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.StatusUC.Requests
{
    public class GetStatusesRequest : IRequest<IEnumerable<Status>>
    {
    }

    public class GetStatusesRequestHandler : IRequestHandler<GetStatusesRequest, IEnumerable<Status>>
    {
        private readonly IStatusReadRepository _statusReadRepository;

        public GetStatusesRequestHandler(IStatusReadRepository statusReadRepository)
        {
            _statusReadRepository = statusReadRepository;
        }

        public async Task<IEnumerable<Status>> Handle(GetStatusesRequest request, CancellationToken cancellationToken)
        {
            return await _statusReadRepository.GetStatusesAsync();
        }
    }
}
