using EF.Domian.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Business.Commands
{
    public class TodoDeleteCommandHandler : IRequestHandler<TodoDeleteCommand, TodoDeleteCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoDeleteCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }
        public async Task<TodoDeleteCommandResponse> Handle(TodoDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _todoRepository.GetByIdAsync(request.Id);

            _todoRepository.Delete(entity);
            // Otras cosas
            return new TodoDeleteCommandResponse { Success = await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken) };
        }
    }
}
