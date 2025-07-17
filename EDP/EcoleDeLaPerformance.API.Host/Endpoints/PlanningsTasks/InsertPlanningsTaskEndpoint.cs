using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningsTaskUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.PlanningsTasks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.PlanningsTasks;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.PlanningsTasks
{
    [HttpPost("planningsTasks"), AllowAnonymous]
    public class InsertPlanningsTaskEndpoint : Endpoint<PlanningsTaskRequest, PlanningsTaskResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertPlanningsTaskEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(PlanningsTaskRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<PlanningsTaskResponse>(await _mediator.Send(new InsertPlanningsTaskCommand
                {
                    planningsTask = _mapper.Map<Core.Domain.Entities.PlanningsTask>(req)
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
