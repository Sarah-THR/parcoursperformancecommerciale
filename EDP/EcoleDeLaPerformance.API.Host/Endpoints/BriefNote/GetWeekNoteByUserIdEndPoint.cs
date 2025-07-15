using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;


namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpGet("briefnote"), AllowAnonymous]

    public class GetWeekNoteByUserIdByUserEndpoint : Endpoint<WeekNoteByUserRequest, IEnumerable<BriefNoteResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetWeekNoteByUserIdByUserEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(WeekNoteByUserRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetWeekNoteByUserRequest
                {
                    userId = req.UserId,
                    startDateWeek = req.StartDateWeek,
                    endDateWeek = req.EndDateWeek,
                }, ct);

                await SendOkAsync(_mapper.Map<IEnumerable<BriefNoteResponse>>(results), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }

    }
}
