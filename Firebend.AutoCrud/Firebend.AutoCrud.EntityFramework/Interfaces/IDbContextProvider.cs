using System.Threading;
using System.Threading.Tasks;
using Firebend.AutoCrud.Core.Interfaces.Models;

namespace Firebend.AutoCrud.EntityFramework.Interfaces
{
    public interface IDbContextProvider<TKey, TEntity>
        where TKey : struct
        where TEntity : IEntity<TKey>
    {
        Task<IDbContext> GetDbContextAsync(CancellationToken cancellationToken = default);
    }
}