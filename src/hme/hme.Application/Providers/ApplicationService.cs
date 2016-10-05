using hme.Application.Adapter;
using hme.Application.Contracts;
using hme.Domain.Authentication;
using hme.Domain.Core;
using hme.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Application.Providers
{
    public class ApplicationService
    {
    }

    public class ApplicationService<TEntity, TId> : ApplicationService, IApplicationService<TEntity, TId> where TEntity : class
    {
        protected IDomainCommonService domainService;

        protected IRepository<TEntity, TId> repository;

        protected ITypeAdapter adapter;

        public ApplicationService(IRepository<TEntity, TId> repository, IDomainCommonService domainService)
        {
            this.repository = repository;
            this.domainService = domainService;
        }

        public ApplicationService(IRepository<TEntity, TId> repository, IDomainCommonService domainService, ITypeAdapter adapter)
           : this(repository, domainService)
        {
            this.adapter = adapter;
        }

        public virtual Task Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("the entity of the type {0} cannot be null", nameof(entity)));

            this.repository.Create(entity);

            return this.repository.IUnitOfWork.CommitAsync();
        }

        public virtual async Task Create(TEntity entity, User user)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("the entity of the type {0} cannot be null", nameof(entity)));

            this.domainService.CreationFields<Audit>(entity as Audit, user);

            await this.repository.Create(entity);

            await this.repository.IUnitOfWork.CommitAsync();
        }

        public virtual async Task Delete(TId id)
        {
            await this.repository.Delete(null, id);

            await this.repository.IUnitOfWork.CommitAsync();
        }

        public Task Delete(TEntity entity, User user)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("the entity of the type {0} cannot be null", nameof(entity)));

            if (user == null)
                throw new ArgumentNullException("the user cannot be null");

            this.repository.Delete(entity);

            return this.repository.IUnitOfWork.CommitAsync();
        }

        public IEnumerable<TEntity> Get()
        {
            return this.repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken token)
        {
            return await this.repository.GetAllAsync(token).ConfigureAwait(false);
        }

        public Task<TEntity> GetSingleAsync(TId id)
        {
            return this.repository.GetByIdAsync(id);
        }

        public Task<TEntity> GetSingleAsync(TId id, CancellationToken token)
        {
            return this.repository.GetByIdAsync(id, token);
        }

        public Task<TEntity> GetSingleByFunc(Func<TEntity, bool> expression)
        {
            return this.repository.GetOneByFunc(expression);
        }

        public async Task Update(TId id, TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("the entity of the type {0} cannot be null", nameof(entity)));

            this.domainService.UpdateFields<Audit>(entity as Audit);

            await this.repository.Update(id, entity);

            await this.repository.IUnitOfWork.CommitAsync();
        }

        public async Task Update(TId id, TEntity entity, User user)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("the entity of the type {0} cannot be null", nameof(entity)));

            if (user == null)
                throw new ArgumentNullException("the user cannot be null");

            this.domainService.UpdateFields<Audit>(entity as Audit, user);

            await this.repository.Update(id, entity);

            await this.repository.IUnitOfWork.CommitAsync();
        }

        public IList<TEntity> GetFiltered(Func<TEntity, TId> orderBy, int skip, int take)
        {
            return this.repository.PageAll(orderBy, skip, take);
        }

        public IList<TEntity> GetFiltered(Func<TEntity, TId> orderBy, int skip, int take, Func<TEntity, bool> filter)
        {
            return this.repository.PageAll(orderBy, skip, take, filter);
        }
    }
}
