using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests
{
    public class GetUserByIdRequest : IRequest<User?>
    {
        public int UserId { get; set; } = default!;
    }

    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, User?>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetUserByIdRequestHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<User?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await _userReadRepository.GetUserByIdAsync(request.UserId);
        }
    }
}
