using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands
{
    public class DeleteDebriefCommand : IRequest
    {
        public int debriefId { get; set; }
    }

    public class DeleteDebriefCommandHandler : IRequestHandler<DeleteDebriefCommand>
    {
        private readonly IDebriefWriteRepository _debriefWriteRepository;

        public DeleteDebriefCommandHandler(IDebriefWriteRepository debriefWriteRepository)
        {
            _debriefWriteRepository = debriefWriteRepository;
        }

        public async Task Handle(DeleteDebriefCommand command, CancellationToken cancellationToken)
        {
            await _debriefWriteRepository.DeleteDebriefAsync(command.debriefId);
        }
    }
}
