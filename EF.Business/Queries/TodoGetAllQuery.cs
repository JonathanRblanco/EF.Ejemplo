using MediatR;
using System.Collections.Generic;

namespace EF.Business.Queries
{
    public class TodoGetAllQuery : IRequest<List<TodoGetAllQueryResponse>>
    {
    }
}
