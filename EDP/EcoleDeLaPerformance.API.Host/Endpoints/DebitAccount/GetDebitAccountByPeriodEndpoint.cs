using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebitAccountUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.DebitAccount;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.DebitAccount
{
    [HttpGet("debitAccountByPeriod"), AllowAnonymous]
    public class GetDebitAccountByPeriodEndpoint(IMapper mapper, IMediator mediator) : Endpoint<DebitAccountByPeriodRequest, int>
    {
        public override async Task HandleAsync(DebitAccountByPeriodRequest req, CancellationToken ct)
        {
            var result = mapper.Map<int>(await mediator.Send(new GetDebitAccountByPeriodRequest
            {
                name = req.name,
                periodFirstDay = req.periodFirstDay,
                periodLastDay = req.periodLastDay,
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
