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
    [HttpPut("documents/"), AllowAnonymous]
    public class UpdateDocumentEndpoint : Endpoint<UpdateDocumentRequest, DocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateDocumentEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(UpdateDocumentRequest req, CancellationToken ct)
        {
            try
            {
                await SendOkAsync(_mapper.Map<DocumentResponse>(await _mediator.Send(new UpdateDocumentCommand
                {
                    document = _mapper.Map<Document>(req)
                }, ct)), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
            catch (ArgumentException)
            {
                await SendNotFoundAsync(cancellation: ct);
            }
        }
    }
}
