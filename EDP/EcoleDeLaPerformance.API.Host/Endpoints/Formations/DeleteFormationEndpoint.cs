using EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Formations
{
    [HttpDelete("formations/{Id:Int}"), AllowAnonymous]
    public class DeleteFormationEndpoint : Endpoint<FormationRequest>
    {
        private readonly IMediator _mediator;
        public DeleteFormationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(FormationRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteFormationCommand
            {
                formationId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
