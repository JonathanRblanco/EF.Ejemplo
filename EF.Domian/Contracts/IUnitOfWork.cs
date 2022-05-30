using System.Threading;
using System.Threading.Tasks;

namespace EF.Domian.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
