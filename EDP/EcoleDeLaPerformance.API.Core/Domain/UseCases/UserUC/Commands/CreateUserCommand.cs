using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User user { get; set; } = default!;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (command.user == null)
                throw new ArgumentNullException("User", "L'utilisateur est obligatoire.");

            return await _userWriteRepository.InsertUserAsync(command.user);
        }
    }
}
