using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Commands
{
    public class CreateWeekCommand : IRequest<Week>
    {
        public Week week { get; set; } = default!;
    }

    public class CreateWeekCommandHandler : IRequestHandler<CreateWeekCommand, Week>
    {
        private readonly IWeekWriteRepository _weekWriteRepository;

        public CreateWeekCommandHandler(IWeekWriteRepository weekWriteRepository)
        {
            _weekWriteRepository = weekWriteRepository;
        }

        public async Task<Week> Handle(CreateWeekCommand command, CancellationToken cancellationToken)
        {
            if (command.week == null)
                throw new ArgumentNullException("Week", "La semaine est obligatoire.");

            return await _weekWriteRepository.CreateWeekAsync(command.week);
        }
    }
}
