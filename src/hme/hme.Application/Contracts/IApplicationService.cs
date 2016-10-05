using hme.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Application.Contracts
{
    public interface IApplicationService<TEntity, TId> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        Task<IEnumerable<TEntity>> GetAsync();

        Task<IEnumerable<TEntity>> GetAsync(CancellationToken token);

        Task<TEntity> GetSingleAsync(TId id);

        Task<TEntity> GetSingleAsync(TId id, CancellationToken token);

        Task<TEntity> GetSingleByFunc(Func<TEntity, bool> expression);

        Task Create(TEntity entity);

        Task Create(TEntity entity, User user);

        Task Update(TId id, TEntity entity);

        Task Update(TId id, TEntity entity, User user);

        Task Delete(TEntity entity, User user);

        Task Delete(TId id);

        IList<TEntity> GetFiltered(Func<TEntity, TId> orderBy, int skip, int take);

        IList<TEntity> GetFiltered(Func<TEntity, TId> orderBy, int skip, int take, Func<TEntity, bool> filter);
    }
}
