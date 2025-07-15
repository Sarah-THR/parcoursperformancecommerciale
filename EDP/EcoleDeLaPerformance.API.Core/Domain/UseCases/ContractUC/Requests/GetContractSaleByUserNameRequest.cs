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
    public class GetContractSaleByUserNameRequest : IRequest<List<VenteOneShot?>>
    {
        public string Commercial { get; set; } = default!;
    }

    public class GetContractSaleByUserNameRequestHandler : IRequestHandler<GetContractSaleByUserNameRequest, List<VenteOneShot?>>
    {
        private readonly IContractReadRepository _contractReadRepository;

        public GetContractSaleByUserNameRequestHandler(IContractReadRepository contractReadRepository)
        {
            _contractReadRepository = contractReadRepository;
        }

        public async Task<List<VenteOneShot?>> Handle(GetContractSaleByUserNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Commercial))
                throw new ArgumentNullException("Commercial", "Le Commercial est obligatoire.");

            return await _contractReadRepository.GetContractSaleByUserNameAsync(request.Commercial);
        }
    }
}
