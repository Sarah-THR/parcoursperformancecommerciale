using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Plannings
{
    [HttpDelete("plannings/{Id:Int}"), AllowAnonymous]
    public class DeletePlanningEndpoint : Endpoint<PlanningRequest>
    {
        private readonly IMediator _mediator;
        public DeletePlanningEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(PlanningRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeletePlanningCommand
            {
                planningId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
