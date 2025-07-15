using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.TurnoverUC.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebitAccountUC.Requests
{
    public class GetDebitAccountByCommercialNameRequest : IRequest<int>
    {
        public string name { get; set; }
    }

    public class GetDebitAccountByCommercialNameRequestHandler : IRequestHandler<GetDebitAccountByCommercialNameRequest, int>
    {
        private readonly IDebitAccountReadRepository _debitAccountReadRepository;

        public GetDebitAccountByCommercialNameRequestHandler(IDebitAccountReadRepository debitAccountReadRepository)
        {
            _debitAccountReadRepository = debitAccountReadRepository;
        }

        public async Task<int> Handle(GetDebitAccountByCommercialNameRequest request, CancellationToken cancellationToken)
        {
            return await _debitAccountReadRepository.GetDebitAccountByCommercialNameAsync(request.name);
        }
    }
}
