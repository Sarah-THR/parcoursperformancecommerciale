using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebitAccountUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.DebitAccount;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.DebitAccount
{
    [HttpGet("debitAccount"), AllowAnonymous]

    public class GetDebitAccountByCommercialNameEndpoint(IMapper mapper, IMediator mediator) : Endpoint<DebitAccountByCommercialNameRequest, int>
    {
        public override async Task HandleAsync(DebitAccountByCommercialNameRequest req, CancellationToken ct)
        {
            var result = mapper.Map<int>(await mediator.Send(new GetDebitAccountByCommercialNameRequest
            {
                name = req.Name
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
