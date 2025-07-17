using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands
{
    public class UpdateGradeCommand : IRequest
    {
        public Grade grade = default!;
    }

    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand>
    {
        private readonly IGradeWriteRepository _gradeWriteRepository;

        public UpdateGradeCommandHandler(IGradeWriteRepository gradeWriteRepository)
        {
            _gradeWriteRepository = gradeWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateGradeCommand command, CancellationToken cancellationToken)
        {
            if (command.grade == null)
                throw new ArgumentNullException("Grade", "Le grade à modifier est obligatoire.");
            command.grade.UpdatedAt = DateTime.Now;
            await _gradeWriteRepository.UpdateGradeAsync(command.grade);
        }
    }
}
