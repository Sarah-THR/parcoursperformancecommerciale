using EcoleDeLaPerformance.API.Core.Domain.UseCases.TaskUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Tasks;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Tasks
{
    [HttpGet("tasks"), AllowAnonymous]
    public class GetTasksEndpoint : EndpointWithoutRequest<IEnumerable<TaskResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetTasksEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<TaskResponse>>(await _mediator.Send(new GetTasksRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
