using EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Weeks
{
    [HttpGet("weeks/{UserId:int}"), AllowAnonymous]
    public class GetWeeksByUserIdEndpoint : Endpoint<GetWeekRequest, IEnumerable<WeekResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetWeeksByUserIdEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(GetWeekRequest req, CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<WeekResponse>>(await _mediator.Send(new GetWeeksByUserIdRequest
            {
                userId = req.UserId
            }, ct));

            if (result.Any())
                await SendOkAsync(result, ct);
            else
                await SendNoContentAsync(ct);
        }
    }
}
