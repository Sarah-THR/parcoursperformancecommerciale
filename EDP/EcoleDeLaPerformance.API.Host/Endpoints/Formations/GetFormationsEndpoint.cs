using EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Formations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Formations
{
    [HttpGet("formations"), AllowAnonymous]
    public class GetFormationsEndpoint : EndpointWithoutRequest<IEnumerable<FormationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetFormationsEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<FormationResponse>>(await _mediator.Send(new GetFormationsRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
