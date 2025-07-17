using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UsersFormationUC.Commands
{
    public class InsertUsersFormationCommand : IRequest<UsersFormation>
    {
        public UsersFormation usersFormation = default!;

        public class InsertUsersFormationCommandHandler : IRequestHandler<InsertUsersFormationCommand, UsersFormation>
        {
            private readonly IUsersFormationWriteRepository _usersFormationWriteRepository;

            public InsertUsersFormationCommandHandler(IUsersFormationWriteRepository usersFormationWriteRepository)
            {
                _usersFormationWriteRepository = usersFormationWriteRepository;
            }

            public async Task<UsersFormation> Handle(InsertUsersFormationCommand command, CancellationToken cancellationToken)
            {
                if (command.usersFormation == null)
                    throw new ArgumentNullException("UsersFormation", "Le usersFormation à insérer est obligatoire.");

                command.usersFormation.CreatedAt = DateTime.Now;
                return await _usersFormationWriteRepository.InsertUsersFormationAsync(command.usersFormation);

            }
        }
    }
}
