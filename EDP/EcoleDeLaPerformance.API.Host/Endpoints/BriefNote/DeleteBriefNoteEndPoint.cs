using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MediatR;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpDelete("briefnote/{briefNoteId:Int}"), AllowAnonymous]

    public class DeleteBriefNoteEndPoint : Endpoint<BriefNoteRequest>
    {
        private readonly IMediator _mediator;
        public DeleteBriefNoteEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(BriefNoteRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteBriefNoteCommand
            {
                 briefNoteId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
