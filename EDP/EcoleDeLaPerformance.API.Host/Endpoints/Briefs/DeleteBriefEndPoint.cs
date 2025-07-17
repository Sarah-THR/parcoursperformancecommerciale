using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
namespace EcoleDeLaPerformance.API.Host.Endpoints.Briefs
{
    [HttpDelete("briefs/{Id:Int}"), AllowAnonymous]

    public class DeleteBriefEndPoint : Endpoint<BriefRequest>
    {
        private readonly IMediator _mediator;
        public DeleteBriefEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(BriefRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteBriefCommand
            {
                briefId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
