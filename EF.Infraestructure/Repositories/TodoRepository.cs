using EF.Domian.Contracts;
using EF.Domian.Models;
using EF.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Infraestructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly EFContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TodoRepository(EFContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Todo> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Todos
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public Task<List<Todo>> GetTodosAsync(CancellationToken cancellationToken = default)
        {
            return _context.Todos.ToListAsync(cancellationToken);
        }
        public async Task<Todo> AddAsync(Todo todo, CancellationToken cancellationToken = default)
        {
            return (await _context.AddAsync(todo)).Entity;
        }

        public void Delete(Todo todo)
        {
            _context.Remove(todo);
        }
    }
}
