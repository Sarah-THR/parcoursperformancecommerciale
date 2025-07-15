using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;
using Microsoft.Data.Sql;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;

namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpPost("briefnote/InsertBriefNote"), AllowAnonymous]

    public class InsertBriefNoteEndpoint : Endpoint<BriefNoteRequest, BriefNoteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertBriefNoteEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(BriefNoteRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<BriefNoteResponse>(await _mediator.Send(new InsertBriefNoteCommand
                {
                    briefNote = _mapper.Map<Core.Domain.Entities.BriefNote>(req)
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

