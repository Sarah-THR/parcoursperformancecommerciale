using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Document;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Documents
{
    [HttpPost("documents"), AllowAnonymous]
    public class CreateDocumentEndpoint : Endpoint<CreateDocumentRequest, DocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateDocumentEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(CreateDocumentRequest req, CancellationToken ct)
        {
            try
            {
                await SendOkAsync(_mapper.Map<DocumentResponse>(await _mediator.Send(new CreateDocumentCommand
                {
                    document = _mapper.Map<Document>(req)
                }, ct)), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
