using EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Document;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Documents
{
    [HttpDelete("documents/{documentId:int}"), AllowAnonymous]

    public class DeleteDocumentEndpoint : Endpoint<DocumentRequest>
    {
        private readonly IMediator _mediator;
        public DeleteDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(DocumentRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteDocumentCommand
            {
                documentId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
