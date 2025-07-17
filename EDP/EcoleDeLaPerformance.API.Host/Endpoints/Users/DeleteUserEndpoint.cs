using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpDelete("users/{userId:int}"), AllowAnonymous]
    public class DeleteUserEndpoint : Endpoint<UserRequest>
    {
        private readonly IMediator _mediator;
        public DeleteUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(UserRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteUserCommand
            {
                userId = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
