using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands
{
    public class InsertBriefCommand : IRequest<Brief>
    {
        public Brief brief = default!;

        public class CreateNotificationCommandHandler : IRequestHandler<InsertBriefCommand, Brief>
        {
            private readonly IBriefWriteRepository _briefWriteRepository;

            public CreateNotificationCommandHandler(IBriefWriteRepository briefWriteRepository)
            {
                _briefWriteRepository = briefWriteRepository;
            }

            public async Task<Brief> Handle(InsertBriefCommand command, CancellationToken cancellationToken)
            {
                if (command.brief == null)
                    throw new ArgumentNullException("brief", "La brief à insérer est obligatoire.");

                command.brief.CreatedAt = DateTime.Now;
                return await _briefWriteRepository.InsertBriefAsync(command.brief);

            }
        }
    }
}
