using EcoleDeLaPerformance.API.Core.Domain.UseCases.UsersFormationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.UsersFormations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.UsersFormations
{
    [HttpPost("usersFormations"), AllowAnonymous]
    public class InsertUsersFormationEndpoint : Endpoint<UsersFormationRequest, UsersFormationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertUsersFormationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UsersFormationRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<UsersFormationResponse>(await _mediator.Send(new InsertUsersFormationCommand
                {
                    usersFormation = _mapper.Map<Core.Domain.Entities.UsersFormation>(req)
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
