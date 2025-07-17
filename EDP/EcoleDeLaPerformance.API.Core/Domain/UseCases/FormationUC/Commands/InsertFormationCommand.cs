using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands
{
    public class InsertFormationCommand : IRequest<Formation>
    {
        public Formation formation = default!;

        public class InsertFormationCommandHandler : IRequestHandler<InsertFormationCommand, Formation>
        {
            private readonly IFormationWriteRepository _formationWriteRepository;

            public InsertFormationCommandHandler(IFormationWriteRepository formationWriteRepository)
            {
                _formationWriteRepository = formationWriteRepository;
            }

            public async Task<Formation> Handle(InsertFormationCommand command, CancellationToken cancellationToken)
            {
                if (command.formation == null)
                    throw new ArgumentNullException("Formation", "La formation à insérer est obligatoire.");

                command.formation.CreatedAt = DateTime.Now;
                return await _formationWriteRepository.InsertFormationAsync(command.formation);

            }
        }
    }
}
