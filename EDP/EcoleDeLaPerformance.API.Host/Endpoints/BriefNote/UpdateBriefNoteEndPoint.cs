using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MediatR;
using IMapper = AutoMapper.IMapper;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;

namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpPut("briefnote/"), AllowAnonymous]

    public class UpdateBriefNoteEndPoint : Endpoint<BriefNoteRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateBriefNoteEndPoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(BriefNoteRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateBriefNoteCommand
                {
                     briefNote = _mapper.Map<Core.Domain.Entities.BriefNote>(req)
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
