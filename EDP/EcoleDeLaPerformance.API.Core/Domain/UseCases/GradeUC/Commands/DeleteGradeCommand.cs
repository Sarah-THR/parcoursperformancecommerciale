using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands
{
    public class DeleteGradeCommand : IRequest
    {
        public int gradeId { get; set; }
    }

    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand>
    {
        private readonly IGradeWriteRepository _gradeWriteRepository;

        public DeleteGradeCommandHandler(IGradeWriteRepository gradeWriteRepository)
        {
            _gradeWriteRepository = gradeWriteRepository;
        }

        public async Task Handle(DeleteGradeCommand command, CancellationToken cancellationToken)
        {
            await _gradeWriteRepository.DeleteGradeAsync(command.gradeId);
        }
    }
}
