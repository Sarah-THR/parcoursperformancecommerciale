using EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Documents
{
    [HttpGet("documents"), AllowAnonymous]
    public class GetDocumentsEndpoint : EndpointWithoutRequest<IEnumerable<DocumentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetDocumentsEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<DocumentResponse>>(await _mediator.Send(new GetDocumentsRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
