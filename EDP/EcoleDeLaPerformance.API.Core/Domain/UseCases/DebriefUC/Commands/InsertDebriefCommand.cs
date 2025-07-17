using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Commands
{
    public class InsertDebriefCommand : IRequest<Debrief>
    {
        public Debrief debrief = default!;

        public class InsertDebriefCommandHandler : IRequestHandler<InsertDebriefCommand, Debrief>
        {
            private readonly IDebriefWriteRepository _debriefWriteRepository;

            public InsertDebriefCommandHandler(IDebriefWriteRepository debriefWriteRepository)
            {
                _debriefWriteRepository = debriefWriteRepository;
            }

            public async Task<Debrief> Handle(InsertDebriefCommand command, CancellationToken cancellationToken)
            {
                if (command.debrief == null)
                    throw new ArgumentNullException("debrief", "Le debrief à insérer est obligatoire.");

                command.debrief.CreatedAt = DateTime.Now;
                return await _debriefWriteRepository.InsertDebriefAsync(command.debrief);

            }
        }
    }
}
