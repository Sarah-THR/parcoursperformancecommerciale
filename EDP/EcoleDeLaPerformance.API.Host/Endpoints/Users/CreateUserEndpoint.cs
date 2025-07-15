using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpPost("users"), AllowAnonymous]
    public class CreateUserEndpoint : Endpoint<CreateUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(CreateUserRequest req, CancellationToken ct)
        {
            try
            {
                await SendOkAsync(_mapper.Map<UserResponse>(await _mediator.Send(new CreateUserCommand
                {
                    user = _mapper.Map<User>(req)
                }, ct)), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
