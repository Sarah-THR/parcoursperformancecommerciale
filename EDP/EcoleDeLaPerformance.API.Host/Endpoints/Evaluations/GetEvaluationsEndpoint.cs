using EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Evaluations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Evaluations
{
    [HttpGet("evaluations"), AllowAnonymous]
    public class GetEvaluationsEndpoint : EndpointWithoutRequest<IEnumerable<EvaluationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetEvaluationsEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<EvaluationResponse>>(await _mediator.Send(new GetEvaluationRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
