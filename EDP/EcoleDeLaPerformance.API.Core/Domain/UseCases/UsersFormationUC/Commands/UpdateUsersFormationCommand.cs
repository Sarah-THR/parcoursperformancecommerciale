using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UsersFormationUC.Commands
{
    public class UpdateUsersFormationCommand : IRequest
    {
        public UsersFormation usersFormation = default!;
    }

    public class UpdateUsersFormationCommandHandler : IRequestHandler<UpdateUsersFormationCommand>
    {
        private readonly IUsersFormationWriteRepository _usersFormationWriteRepository;

        public UpdateUsersFormationCommandHandler(IUsersFormationWriteRepository usersFormationWriteRepository)
        {
            _usersFormationWriteRepository = usersFormationWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateUsersFormationCommand command, CancellationToken cancellationToken)
        {
            if (command.usersFormation == null)
                throw new ArgumentNullException("UsersFormation", "Le usersFormation à modifier est obligatoire.");
            command.usersFormation.UpdatedAt = DateTime.Now;
            await _usersFormationWriteRepository.UpdateUsersFormationAsync(command.usersFormation);
        }
    }
}
