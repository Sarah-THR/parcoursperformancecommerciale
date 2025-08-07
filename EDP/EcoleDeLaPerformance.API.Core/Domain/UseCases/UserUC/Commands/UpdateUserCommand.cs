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

            user.Name = command.user.Name;
            user.Entity = command.user.Entity;
            user.ProfilePicturePath = command.user.ProfilePicturePath;
            user.Email = command.user.Email;
            user.SupervisorId = command.user.SupervisorId;
            user.RoleId = command.user.RoleId;
            user.GradeId = command.user.GradeId;
            user.DeletedAt = command.user.DeletedAt;
            user.IsFirstConnection = command.user.IsFirstConnection;
            return await _userWriteRepository.UpdateUserAsync(user);
        }
    }
}
