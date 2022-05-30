using EF.Domian.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Domian.Contracts
{
    public interface ITodoRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Todo> GetByIdAsync(int Id, CancellationToken cancellationToken = default);
        Task<List<Todo>> GetTodosAsync(CancellationToken cancellationToken = default);
        Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken = default);
        void Delete(Todo todo);
    }
}
