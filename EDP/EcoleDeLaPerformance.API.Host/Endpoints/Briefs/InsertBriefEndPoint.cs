using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.BriefNote
{
    [HttpPost("briefs"), AllowAnonymous]

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
                    brief = _mapper.Map<Core.Domain.Entities.Brief>(req)
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

