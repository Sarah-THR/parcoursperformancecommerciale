using EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Debriefs
{
    [HttpPost("debriefs"), AllowAnonymous]
    public class InsertDebriefEndpoint : Endpoint<DebriefRequest, DebriefResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertDebriefEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(DebriefRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<DebriefResponse>(await _mediator.Send(new InsertDebriefCommand
                {
                    debrief = _mapper.Map<API.Core.Domain.Entities.Debrief>(req)
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
