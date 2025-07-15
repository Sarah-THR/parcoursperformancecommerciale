using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Commands
{
    public class UpdateWeekCommand : IRequest
    {
        public Week week = default!;
    }
    public class UpdateWeekCommandHandler : IRequestHandler<UpdateWeekCommand>
    {
        private readonly IWeekWriteRepository _weekWriteRepository;

        public UpdateWeekCommandHandler(IWeekWriteRepository weekWriteRepository)
        {
            _weekWriteRepository = weekWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateWeekCommand command, CancellationToken cancellationToken)
        {
            if (command.week == null)
                throw new ArgumentNullException("Week", "La semaine à modifier est obligatoire.");
            await _weekWriteRepository.UpdateWeekAsync(command.week);
        }
    }

}
