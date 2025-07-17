using EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Formations
{
    [HttpPut("formations"), AllowAnonymous]
    public class UpdateFormationEndpoint : Endpoint<FormationRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateFormationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(FormationRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateFormationCommand
                {
                    formation = _mapper.Map<Core.Domain.Entities.Formation>(req)
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
