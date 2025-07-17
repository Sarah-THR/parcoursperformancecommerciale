using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Debriefs
{
    [HttpPut("debriefs/"), AllowAnonymous]
    public class UpdateDebriefEndpoint : Endpoint<DebriefRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateDebriefEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(DebriefRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateDebriefCommand
                {
                    debrief = _mapper.Map<Core.Domain.Entities.Debrief>(req)
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
