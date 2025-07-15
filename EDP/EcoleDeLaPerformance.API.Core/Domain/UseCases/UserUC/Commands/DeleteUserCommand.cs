using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.DocumentUC.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int userId { get; set; }
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
            await _userWriteRepository.DeleteUserAsync(command.userId);
        }
    }
}
