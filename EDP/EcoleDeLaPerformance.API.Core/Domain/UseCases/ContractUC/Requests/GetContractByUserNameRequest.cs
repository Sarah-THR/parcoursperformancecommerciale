using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.ContractUC.Requests
{
    public class GetContractByUserNameRequest : IRequest<List<EcolePerformanceSm?>>
    {
        public string Commercial { get; set; } = default!;
    }

    public class GetContractByUserNameRequestHandler : IRequestHandler<GetContractByUserNameRequest, List<EcolePerformanceSm?>>
    {
        private readonly IContractReadRepository _contractReadRepository;

        public GetContractByUserNameRequestHandler(IContractReadRepository contractReadRepository)
        {
            _contractReadRepository = contractReadRepository;
        }

        public async Task<List<EcolePerformanceSm?>> Handle(GetContractByUserNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Commercial))
                throw new ArgumentNullException("Commercial", "Le Commercial est obligatoire.");

            return await _contractReadRepository.GetContractByUserNameAsync(request.Commercial);
        }
    }
}
