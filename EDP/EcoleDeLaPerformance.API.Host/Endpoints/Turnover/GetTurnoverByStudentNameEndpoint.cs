using EcoleDeLaPerformance.API.Core.Domain.UseCases.TurnoverUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Turnover;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Turnover
{
    [HttpGet("turnover"), AllowAnonymous]

    public class GetTurnoverByStudentNameEndpoint(IMapper mapper, IMediator mediator) : Endpoint<TurnoverByStudentNameRequest, decimal>
    {
        public override async Task HandleAsync(TurnoverByStudentNameRequest req, CancellationToken ct)
        {
            var result = mapper.Map<decimal>(await mediator.Send(new GetTurnoverByStudentNameRequest
            {
                name = req.name,
                startDate = req.startDate,
                endDate = req.endDate,
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
