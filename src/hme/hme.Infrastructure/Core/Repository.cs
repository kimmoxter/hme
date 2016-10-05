using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using hme.Infrastructure.Contracts;
using hme.Domain.Core;
using System.Data.Entity;

namespace hme.Infrastructure.Core
{
    public class Repository
    {        
    }

    public class Repository<TEntity, TId> : Repository, IRepository<TEntity, TId> where TEntity : class
    {
        private IUnitOfWork unitOfWork;
        public Repository(IQueryableUnitOfWork IUnitOfWork)
        {
            if (IUnitOfWork == null)            
                throw new ArgumentNullException(nameof(IUnitOfWork));

            this.unitOfWork = IUnitOfWork;
        }

        public IUnitOfWork IUnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public Task Create(TEntity entity)
        {
            this.GetSet().Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(TEntity entity)
        {
            //set as "removed"
            this.GetSet().Remove(entity);
            return Task.CompletedTask;
        }

        public Task Delete(TEntity entity, TId Id)
        {
            //set as "removed"
            var ent = this.GetById(Id);

            this.GetSet().Remove(ent);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }

        public IList<TEntity> GetAll()
        {
            return this.GetSet().ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return this.GetSet().ToListAsync<TEntity>();
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken token)
        {
            return this.GetSet().ToListAsync<TEntity>(token);
        }

        public Task<List<TEntity>> GetByFunc(Func<TEntity, bool> expression)
        {
            return Task.FromResult(this.GetSet().Where(expression).ToList());
        }

        public Task<IList<TEntity>> GetByFunc(Func<TEntity, bool> expression, CancellationToken token)
        {
            return Task.FromResult(
              this.GetSet()
              .Where<TEntity>(expression)
              .ToList()) as Task<IList<TEntity>>;
        }

        public TEntity GetById(TId Id)
        {
            return this.GetSet().Find(Id);
        }

        public Task<TEntity> GetByIdAsync(TId Id)
        {
            return (this.GetSet() as DbSet<TEntity>).FindAsync(Id);
        }

        public Task<TEntity> GetByIdAsync(TId Id, CancellationToken token)
        {
            return (this.GetSet() as DbSet<TEntity>).FindAsync(token, Id);
        }

        public Task<TEntity> GetOneByFunc(Func<TEntity, bool> expression)
        {
            return Task.FromResult(this.GetSet().FirstOrDefault(expression));
        }

        public IList<TEntity> PageAll(Func<TEntity, TId> orderBy, int skip, int take)
        {
            return this.GetSet().OrderBy(orderBy).Skip(skip).Take(take).ToList();
        }        

        public IList<TEntity> PageAll(Func<TEntity, TId> orderBy, int skip, int take, Func<TEntity, bool> callback)
        {
            return this.GetSet().Where(callback).OrderBy(orderBy).Skip(skip).Take(take).ToList();
        }

        public Task Update(TId id, TEntity newEntity)
        {
            var olderEntity  = this.GetById(id);

            if (olderEntity == null)
            {
                throw new NullReferenceException("don't find the entity with the id " + olderEntity.ToString());
            }

            return ((IQueryableUnitOfWork)this.unitOfWork).Update<TEntity>(olderEntity, newEntity);
        }
        
        private IDbSet<TEntity> GetSet()
        {
            return ((IQueryableUnitOfWork)this.unitOfWork).CreateSet<TEntity>();
        }
    }
}
