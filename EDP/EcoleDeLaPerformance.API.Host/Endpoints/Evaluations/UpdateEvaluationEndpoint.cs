using EcoleDeLaPerformance.API.Core.Domain.UseCases.EvaluationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Evaluations
{
    [HttpPut("evaluations"), AllowAnonymous]
    public class UpdateEvaluationEndpoint : Endpoint<UpdateEvaluationRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateEvaluationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateEvaluationRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateEvaluationCommand
                {
                    evaluation = _mapper.Map<Core.Domain.Entities.Evaluation>(req)
                }, ct);

                await SendOkAsync(ct);
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
