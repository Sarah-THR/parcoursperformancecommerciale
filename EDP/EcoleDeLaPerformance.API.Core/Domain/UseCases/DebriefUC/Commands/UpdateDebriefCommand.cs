using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands
{
    public class UpdateDebriefCommand : IRequest
    {
        public Debrief debrief = default!;
    }

    public class UpdateDebriefCommandHandler : IRequestHandler<UpdateDebriefCommand>
    {
        private readonly IDebriefWriteRepository _debriefWriteRepository;

        public UpdateDebriefCommandHandler(IDebriefWriteRepository debriefWriteRepository)
        {
            _debriefWriteRepository = debriefWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateDebriefCommand command, CancellationToken cancellationToken)
        {
            if (command.debrief == null)
                throw new ArgumentNullException("Debrief", "Le debrief à modifier est obligatoire.");
            command.debrief.UpdatedAt = DateTime.Now;
            await _debriefWriteRepository.UpdateDebriefAsync(command.debrief);
        }
    }
}
