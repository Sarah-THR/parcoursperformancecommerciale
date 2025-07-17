using EcoleDeLaPerformance.API.Core.Domain.UseCases.StatusUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Statuses;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Statuses
{
    [HttpGet("statuses"), AllowAnonymous]
    public class GetStatusesEndpoint : EndpointWithoutRequest<IEnumerable<StatusResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetStatusesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<StatusResponse>>(await _mediator.Send(new GetStatusesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
