using hme.Domain.Authentication;
using hme.Domain.Core;
using System;

namespace hme.Domain.Services
{
    public interface IDomainService
    {
    }

    public interface IDomainCommonService
    {
        void UpdateFields<TEntity>(TEntity entity) where TEntity : Audit;
        void UpdateFields<TEntity>(TEntity entity, User user) where TEntity : Audit;

        void CreationFields<TEntity>(TEntity entity, User user) where TEntity : Audit;
    }

    public class DomainCommonService : IDomainCommonService
    {
        public void CreationFields<TEntity>(TEntity entity, User user) where TEntity : Audit
        {
            entity.DateCreation = DateTime.Now;
            entity.UserCreation = user.Email;

            this.UpdateFields<TEntity>(entity, user);
        }

        public void UpdateFields<TEntity>(TEntity entity) where TEntity : Audit
        {
            entity.DateModification = DateTime.Now;
        }

        public void UpdateFields<TEntity>(TEntity entity, User user) where TEntity : Audit
        {
            entity.DateModification = DateTime.Now;
            entity.UserModification = user.Email;
        }
    }
}
