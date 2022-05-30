using AutoMapper;
using EF.Domian.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Business.Queries
{
    public class TodoGetAllQueryHandler : IRequestHandler<TodoGetAllQuery, List<TodoGetAllQueryResponse>>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoGetAllQueryHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<TodoGetAllQueryResponse>> Handle(TodoGetAllQuery request, CancellationToken cancellationToken)
        {
            var list = await _todoRepository.GetTodosAsync(cancellationToken);
            return _mapper.Map<List<TodoGetAllQueryResponse>>(list);
        }
    }
}
