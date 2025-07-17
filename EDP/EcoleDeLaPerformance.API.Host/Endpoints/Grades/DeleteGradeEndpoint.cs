using EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Grades
{
    [HttpDelete("grades/{Id:Int}"), AllowAnonymous]
    public class DeleteGradeEndpoint : Endpoint<GradeRequest>
    {
        private readonly IMediator _mediator;
        public DeleteGradeEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(GradeRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteGradeCommand
            {
                gradeId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
