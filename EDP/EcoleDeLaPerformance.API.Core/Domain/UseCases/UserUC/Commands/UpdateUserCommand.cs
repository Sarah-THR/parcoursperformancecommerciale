using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User user = default!;
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (command.user == null)
                throw new ArgumentNullException("User", "Le profil à modifier est obligatoire.");

            var user = await _userReadRepository.GetUserByIdAsync(command.user.Id)
                ?? throw new ArgumentException($"Le profil avec l'id {command.user.Id} n'existe pas.");

            user.FirstName = command.user.FirstName;
            user.LastName = command.user.LastName;
            user.Entity = command.user.Entity;
            user.ProfilePicture = command.user.ProfilePicture;
            user.Email = command.user.Email;
            user.Supervisor = command.user.Supervisor;
            user.Role = command.user.Role;
            user.IsActive = command.user.IsActive;
            return await _userWriteRepository.UpdateUserAsync(user);
        }
    }
}
