using EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Evaluations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Evaluations
{
    [HttpPost("evaluations"), AllowAnonymous]
    public class InsertEvaluationEndpoint : Endpoint<EvaluationRequest, EvaluationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertEvaluationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(EvaluationRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<EvaluationResponse>(await _mediator.Send(new InsertEvaluationCommand
                {
                    evaluation = _mapper.Map<Core.Domain.Entities.Evaluation>(req)
                }, ct));

                await SendOkAsync(result, ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
