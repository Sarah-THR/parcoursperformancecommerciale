using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.ContractUC.Requests
{
    public class GetContractNexleaseByUserNameRequest : IRequest<List<NexleaseContract?>>
    {
        public string Commercial { get; set; } = default!;
    }

    public class GetContractNexleaseByUserNameRequestHandler : IRequestHandler<GetContractNexleaseByUserNameRequest, List<NexleaseContract?>>
    {
        private readonly IContractReadRepository _contractReadRepository;

        public GetContractNexleaseByUserNameRequestHandler(IContractReadRepository contractReadRepository)
        {
            _contractReadRepository = contractReadRepository;
        }

        public async Task<List<NexleaseContract?>> Handle(GetContractNexleaseByUserNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Commercial))
                throw new ArgumentNullException("Commercial", "Le Commercial est obligatoire.");

            return await _contractReadRepository.GetContractNexleaseByUserNameAsync(request.Commercial);
        }
    }
}
