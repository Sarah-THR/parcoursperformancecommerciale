using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Briefs
{
    [HttpPut("briefs"), AllowAnonymous]

    public class UpdateBriefEndPoint : Endpoint<UpdateBriefRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateBriefEndPoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateBriefRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateBriefCommand
                {
                    brief = _mapper.Map<Core.Domain.Entities.Brief>(req)
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
