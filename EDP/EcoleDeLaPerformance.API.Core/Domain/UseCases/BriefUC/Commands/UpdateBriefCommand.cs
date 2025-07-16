using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands
{
    public class UpdateBriefCommand : IRequest
    {
        public Brief brief = default!;
    }

    public class UpdateBriefCommandsHandler : IRequestHandler<UpdateBriefCommand>
    {
        private readonly IBriefWriteRepository _briefWriteRepository;

        public UpdateBriefCommandsHandler(IBriefWriteRepository briefWriteRepository)
        {
            _briefWriteRepository = briefWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateBriefCommand command, CancellationToken cancellationToken)
        {
            if (command.brief == null)
                throw new ArgumentNullException("Brief", "La brief à modifier est obligatoire.");
            command.brief.UpdatedAt = DateTime.Now;
            await _briefWriteRepository.UpdateBriefAsync(command.brief);
        }
    }
}
