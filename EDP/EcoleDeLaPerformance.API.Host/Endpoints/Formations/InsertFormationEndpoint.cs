using EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Formations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Formations
{
    [HttpPost("formations"), AllowAnonymous]
    public class InsertFormationEndpoint : Endpoint<FormationRequest, FormationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertFormationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(FormationRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<FormationResponse>(await _mediator.Send(new InsertFormationCommand
                {
                    formation = _mapper.Map<Core.Domain.Entities.Formation>(req)
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
