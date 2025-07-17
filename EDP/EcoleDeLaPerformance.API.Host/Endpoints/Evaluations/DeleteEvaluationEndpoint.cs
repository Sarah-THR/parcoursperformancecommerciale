using EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Evaluations
{
    [HttpDelete("evaluations/{Id:Int}"), AllowAnonymous]
    public class DeleteEvaluationEndpoint : Endpoint<EvaluationRequest>
    {
        private readonly IMediator _mediator;
        public DeleteEvaluationEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(EvaluationRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteEvaluationCommand
            {
                evaluationId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
