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
    public class GetNbContractByUserNameRequest : IRequest<int>
    {
        public string Commercial { get; set; } = default!;
        public DateOnly StartDate { get; set; } = default!;
        public DateOnly EndDate { get; set; } = default!;
    }

    public class GetNbContractByUserNameRequestHandler : IRequestHandler<GetNbContractByUserNameRequest, int>
    {
        private readonly IContractReadRepository _contractReadRepository;

        public GetNbContractByUserNameRequestHandler(IContractReadRepository contractReadRepository)
        {
            _contractReadRepository = contractReadRepository;
        }

        public async Task<int> Handle(GetNbContractByUserNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Commercial))
                throw new ArgumentNullException("Commercial", "Le Commercial est obligatoire.");
            
            return await _contractReadRepository.GetNbContractByUserNameAsync(request.Commercial, request.StartDate, request.EndDate);
        }
    }
}
