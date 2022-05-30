using AutoMapper;
using EF.Domian.Contracts;
using EF.Domian.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Business.Commands
{
    public class TodoCreateCommandHandler : IRequestHandler<TodoCreateCommand, TodoCreateCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoCreateCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TodoCreateCommandResponse> Handle(TodoCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Todo>(request);
            // .....
            // Otras cosas del negocio
            entity = await _todoRepository.AddAsync(entity);
            // Otras cosas

            await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return _mapper.Map<TodoCreateCommandResponse>(entity);

        }
    }
}
