using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Commands
{
    public class DeleteBriefCommand : IRequest
    {
        public int briefId { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteBriefCommand>
    {
        private readonly IBriefWriteRepository _briefWriteRepository;

        public DeleteCommentCommandHandler(IBriefWriteRepository briefWriteRepository)
        {
            _briefWriteRepository = briefWriteRepository;
        }

        public async Task Handle(DeleteBriefCommand command, CancellationToken cancellationToken)
        {
            await _briefWriteRepository.DeleteBriefAsync(command.briefId);
        }
    }
}
