using EcoleDeLaPerformance.API.Core.Domain.UseCases.UsersFormationUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.UsersFormations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.UsersFormations
{
    [HttpPut("usersFormations"), AllowAnonymous]
    public class UpdateUsersFormationEndpoint : Endpoint<UpdateUsersFormationRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateUsersFormationEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateUsersFormationRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateUsersFormationCommand
                {
                    usersFormation = _mapper.Map<Core.Domain.Entities.UsersFormation>(req)
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
