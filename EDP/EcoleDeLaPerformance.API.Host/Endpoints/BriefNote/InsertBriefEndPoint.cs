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

    public class InsertBriefEndPoint : Endpoint<BriefRequest, BriefResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertBriefEndPoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(BriefRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<BriefResponse>(await _mediator.Send(new InsertBriefCommand
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

