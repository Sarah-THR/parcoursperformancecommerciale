using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Commands
{
    public class DeleteFormationCommand : IRequest
    {
        public int formationId { get; set; }
    }

    public class DeleteFormationCommandHandler : IRequestHandler<DeleteFormationCommand>
    {
        private readonly IFormationWriteRepository _formationWriteRepository;

        public DeleteFormationCommandHandler(IFormationWriteRepository formationWriteRepository)
        {
            _formationWriteRepository = formationWriteRepository;
        }

        public async Task Handle(DeleteFormationCommand command, CancellationToken cancellationToken)
        {
            await _formationWriteRepository.DeleteFormationAsync(command.formationId);
        }
    }
}
