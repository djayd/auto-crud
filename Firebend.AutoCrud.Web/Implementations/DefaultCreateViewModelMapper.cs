using Firebend.AutoCrud.Core.Interfaces.Models;
using Firebend.AutoCrud.Web.Interfaces;
using Firebend.AutoCrud.Web.Models;

namespace Firebend.AutoCrud.Web.Implementations
{
    public class DefaultCreateViewModelMapper<TKey, TEntity> :
        AbstractDefaultCreateUpdateViewModelMapper<TKey, TEntity>,
        ICreateViewModelMapper<TKey, TEntity, DefaultCreateUpdateViewModel<TKey, TEntity>>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
    }
}
