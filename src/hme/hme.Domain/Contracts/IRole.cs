using hme.Domain.Authentication;
using hme.Domain.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Domain.Contracts
{
    public interface IRole : IRepository<Role, Guid>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(string roleName, CancellationToken cancellationToken);
    }
}
