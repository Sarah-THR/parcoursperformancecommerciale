using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Plannings
{
    [HttpPut("plannings"), AllowAnonymous]
    public class UpdatePlanningEndpoint : Endpoint<UpdatePlanningRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatePlanningEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdatePlanningRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdatePlanningCommand
                {
                    planning = _mapper.Map<Core.Domain.Entities.Planning>(req)
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
