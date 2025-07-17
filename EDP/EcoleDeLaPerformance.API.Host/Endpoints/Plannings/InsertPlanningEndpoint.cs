using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Plannings
{
    [HttpPost("plannings"), AllowAnonymous]
    public class InsertPlanningEndpoint : Endpoint<PlanningRequest, PlanningResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertPlanningEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(PlanningRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<PlanningResponse>(await _mediator.Send(new InsertPlanningCommand
                {
                    planning = _mapper.Map<Core.Domain.Entities.Planning>(req)
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
