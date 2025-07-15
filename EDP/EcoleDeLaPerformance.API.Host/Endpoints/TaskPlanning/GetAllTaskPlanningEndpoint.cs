using EcoleDeLaPerformance.API.Core.Domain.UseCases.ClassUC.Requests;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.TaskPlanningUC;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Classes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.TaskPlannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.TaskPlanning
{
    [HttpGet("taskplanning"), AllowAnonymous]

    public class GetAllTaskPlanningEndpoint : EndpointWithoutRequest<IEnumerable<TaskPlanningResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetAllTaskPlanningEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<TaskPlanningResponse>>(await _mediator.Send(new GetAllTaskPlanningRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
