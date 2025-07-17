using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Debriefs
{
    [HttpDelete("debriefs/{Id:Int}"), AllowAnonymous]
    public class DeleteDebriefEndpoint : Endpoint<DebriefRequest>
    {
        private readonly IMediator _mediator;
        public DeleteDebriefEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(DebriefRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteDebriefCommand
            {
                debriefId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
