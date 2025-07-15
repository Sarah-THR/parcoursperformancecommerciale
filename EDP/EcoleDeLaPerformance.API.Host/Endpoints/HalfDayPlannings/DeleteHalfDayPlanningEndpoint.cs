using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings
{
    [HttpDelete("halfdayplanning/{HalfDayId:int}"), AllowAnonymous]

    public class DeleteHalfDayPlanningEndpoint : Endpoint<HalfDayPlanningRequest>
    {
        private readonly IMediator _mediator;
        public DeleteHalfDayPlanningEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(HalfDayPlanningRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteHalfDayPlanningCommand
            {
                halfDayPlanningId = req.HalfDayId
            }, ct);

            await SendOkAsync(ct);
        }
    }
}
