using EcoleDeLaPerformance.API.Core.Domain.UseCases.TurnoverUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Turnover;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Turnover
{
    [HttpGet("monthGoal"), AllowAnonymous]
    public class GetMonthGoalByUserEndpoint(IMapper mapper, IMediator mediator) : Endpoint<MonthGoalByUserRequest, decimal>
    {
        public override async Task HandleAsync(MonthGoalByUserRequest req, CancellationToken ct)
        {
            var result = mapper.Map<decimal>(await mediator.Send(new GetMonthGoalByUserRequest
            {
                name = req.name,
                goalsDate = req.goalsDate,
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
