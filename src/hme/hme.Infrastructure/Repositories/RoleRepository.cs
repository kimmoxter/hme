using hme.Domain.Authentication;
using hme.Domain.Contracts;
using hme.Infrastructure.Contracts;
using hme.Infrastructure.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role, Guid>, IRole
    {
        public RoleRepository(IQueryableUnitOfWork IUnitOfWork)
            : base(IUnitOfWork)
        {
        }

        public Role FindByName(string roleName)
        {
            return (this.IUnitOfWork as IQueryableUnitOfWork)
                .CreateSet<Role>()
                .FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return (this.IUnitOfWork as IQueryableUnitOfWork)
              .CreateSet<Role>()
              .FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName, CancellationToken cancellationToken)
        {
            return (this.IUnitOfWork as IQueryableUnitOfWork)
              .CreateSet<Role>()
              .FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
