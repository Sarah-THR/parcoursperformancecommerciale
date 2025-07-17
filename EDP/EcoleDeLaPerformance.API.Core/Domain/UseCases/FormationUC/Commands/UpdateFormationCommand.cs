using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands
{
    public class UpdateFormationCommand : IRequest
    {
        public Formation formation = default!;
    }

    public class UpdateFormationCommandHandler : IRequestHandler<UpdateFormationCommand>
    {
        private readonly IFormationWriteRepository _formationWriteRepository;

        public UpdateFormationCommandHandler(IFormationWriteRepository formationWriteRepository)
        {
            _formationWriteRepository = formationWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateFormationCommand command, CancellationToken cancellationToken)
        {
            if (command.formation == null)
                throw new ArgumentNullException("Formation", "La formation à modifier est obligatoire.");
            command.formation.UpdatedAt = DateTime.Now;
            await _formationWriteRepository.UpdateFormationAsync(command.formation);
        }
    }
}
