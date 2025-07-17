using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpGet("briefs"), AllowAnonymous]

    public class GetBriefByUserIdByUserEndpoint : Endpoint<BriefByUserRequest, IEnumerable<BriefResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetBriefByUserIdByUserEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(BriefByUserRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetBriefByUserRequest
                {
                    userId = req.UserId,
                    startDateWeek = req.StartDateWeek,
                    endDateWeek = req.EndDateWeek,
                }, ct);

                await SendOkAsync(_mapper.Map<IEnumerable<BriefResponse>>(results), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }

    }
}
