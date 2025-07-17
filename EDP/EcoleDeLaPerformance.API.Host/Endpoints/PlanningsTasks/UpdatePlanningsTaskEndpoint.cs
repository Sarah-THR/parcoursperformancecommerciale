using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningsTaskUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.PlanningsTasks;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.PlanningsTasks
{
    [HttpPut("planningsTasks"), AllowAnonymous]
    public class UpdatePlanningsTaskEndpoint : Endpoint<UpdatePlanningsTaskRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatePlanningsTaskEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdatePlanningsTaskRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdatePlanningsTaskCommand
                {
                    planningsTask = _mapper.Map<Core.Domain.Entities.PlanningsTask>(req)
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
