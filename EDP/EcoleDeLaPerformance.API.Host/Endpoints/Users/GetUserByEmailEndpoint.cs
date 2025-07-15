using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpGet("users/{email}"), AllowAnonymous]

    public class GetUserByEmailEndpoint : Endpoint<UserByEmailRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetUserByEmailEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(UserByEmailRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<UserResponse>(await _mediator.Send(new GetUserByEmailRequest
                {
                    Email = req.Email
                }, ct));

                if (result == null)
                    await SendNoContentAsync(cancellation: ct);
                else
                    await SendOkAsync(result, ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
