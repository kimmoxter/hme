using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Domain.Core
{

    public interface IRepository : IDisposable
    {
        IUnitOfWork IUnitOfWork { get; }
    }

    public interface IRepository<TEntity, TId> : IRepository where TEntity : class
    {
        TEntity GetById(TId Id);

        Task<TEntity> GetByIdAsync(TId Id);

        Task<TEntity> GetByIdAsync(TId Id, CancellationToken token);

        IList<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllAsync(CancellationToken token);

        Task<List<TEntity>> GetByFunc(Func<TEntity, bool> expression);

        Task<IList<TEntity>> GetByFunc(Func<TEntity, bool> expression, CancellationToken token);

        Task<TEntity> GetOneByFunc(Func<TEntity, bool> expression);        

        IList<TEntity> PageAll(Func<TEntity, TId> orderBy, int skip, int take);

        IList<TEntity> PageAll(Func<TEntity, TId> orderBy, int skip, int take, Func<TEntity, bool> callback);

        Task Create(TEntity entity);

        Task Update(TId id, TEntity newEntity);

        Task Delete(TEntity entity);

        Task Delete(TEntity entity, TId Id);
    }
}
