using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands
{
    public class InsertGradeCommand : IRequest<Grade>
    {
        public Grade grade = default!;

        public class InsertGradeCommandHandler : IRequestHandler<InsertGradeCommand, Grade>
        {
            private readonly IGradeWriteRepository _gradeWriteRepository;

            public InsertGradeCommandHandler(IGradeWriteRepository gradeWriteRepository)
            {
                _gradeWriteRepository = gradeWriteRepository;
            }

            public async Task<Grade> Handle(InsertGradeCommand command, CancellationToken cancellationToken)
            {
                if (command.grade == null)
                    throw new ArgumentNullException("Grade", "Le grade à insérer est obligatoire.");

                command.grade.CreatedAt = DateTime.Now;
                return await _gradeWriteRepository.InsertGradeAsync(command.grade);

            }
        }
    }
}
