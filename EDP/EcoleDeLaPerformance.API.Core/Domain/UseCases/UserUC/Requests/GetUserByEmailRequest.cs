using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests
{
    public class GetUserByEmailRequest : IRequest<User?>
    {
        public string Email { get; set; } = default!;
    }

    public class GetUserByEmailRequestHandler : IRequestHandler<GetUserByEmailRequest, User?>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetUserByEmailRequestHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<User?> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentNullException("Email", "L'email est obligatoire.");

            return await _userReadRepository.GetUserByEmailAsync(request.Email);
        }
    }
}
