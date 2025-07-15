using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpPut("users/"), AllowAnonymous]
    public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateUserEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
        {
            try
            {
                await SendOkAsync(_mapper.Map<UserResponse>(await _mediator.Send(new UpdateUserCommand
                {
                    user = _mapper.Map<User>(req)
                }, ct)), ct);
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
