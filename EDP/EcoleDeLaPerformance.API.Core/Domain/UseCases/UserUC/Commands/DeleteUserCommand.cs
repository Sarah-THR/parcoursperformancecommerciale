using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _userWriteRepository.SoftDeleteUserAsync(command.Id);
        }
    }
}
