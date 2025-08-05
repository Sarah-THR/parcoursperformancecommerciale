using EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Plannings
{
    [HttpGet("plannings/{Id:int}"), AllowAnonymous]
    public class GetPlanningByIdEndpoint : Endpoint<PlanningByIdRequest, PlanningResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetPlanningByIdEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(PlanningByIdRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetPlanningById
                {
                    id = req.Id,
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
