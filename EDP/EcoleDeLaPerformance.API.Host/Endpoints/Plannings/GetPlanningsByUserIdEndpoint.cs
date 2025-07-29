using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Plannings
{
    [HttpGet("plannings"), AllowAnonymous]
    public class GetPlanningsByUserIdEndpoint : Endpoint<PlanningByUserIdRequest, PlanningResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetPlanningsByUserIdEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(PlanningByUserIdRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetPlanningsByUserId
                {
                    userId = req.UserId,
                    startDateWeek = req.StartDateWeek,
                    endDateWeek = req.EndDateWeek,
                }, ct);

                await SendOkAsync(_mapper.Map<PlanningResponse>(results), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }

    }
}
