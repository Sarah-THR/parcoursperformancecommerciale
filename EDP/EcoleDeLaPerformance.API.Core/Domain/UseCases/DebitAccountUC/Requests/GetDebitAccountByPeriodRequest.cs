using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebitAccountUC.Requests
{
    public class GetDebitAccountByPeriodRequest : IRequest<int>
    {
        public string name { get; set; }
        public DateOnly periodFirstDay { get; set; }
        public DateOnly periodLastDay { get; set; }
    }

    public class GetDebitAccountByPeriodRequestHandler : IRequestHandler<GetDebitAccountByPeriodRequest, int>
    {
        private readonly IDebitAccountReadRepository _debitAccountReadRepository;

        public GetDebitAccountByPeriodRequestHandler(IDebitAccountReadRepository debitAccountReadRepository)
        {
            _debitAccountReadRepository = debitAccountReadRepository;
        }

        public async Task<int> Handle(GetDebitAccountByPeriodRequest request, CancellationToken cancellationToken)
        {
            return await _debitAccountReadRepository.GetDebitAccountByPeriodAsync(request.name, request.periodFirstDay, request.periodLastDay);
        }
    }
}
