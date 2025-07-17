using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Debriefs
{
    [HttpGet("debriefs"), AllowAnonymous]
    public class GetDebriefByUserIdEndpoint : Endpoint<DebriefByUserRequest, IEnumerable<DebriefResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetDebriefByUserIdEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(DebriefByUserRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetDebriefByUserIdRequest
                {
                    userId = req.UserId,
                    startDateWeek = req.StartDateWeek,
                    endDateWeek = req.EndDateWeek,
                }, ct);

                await SendOkAsync(_mapper.Map<IEnumerable<DebriefResponse>>(results), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }

    }
}
