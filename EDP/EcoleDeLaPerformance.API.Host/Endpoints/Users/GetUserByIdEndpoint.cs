using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpGet("users/{UserId:int}"), AllowAnonymous]

    public class GetUserByIdEndpoint(IMapper mapper, IMediator mediator) : Endpoint<UserByIdRequest, UserResponse>
    {
        public override async Task HandleAsync(UserByIdRequest req, CancellationToken ct)
        {
            var result = mapper.Map<UserResponse>(await mediator.Send(new GetUserByIdRequest
            {
                UserId = req.UserId,
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
