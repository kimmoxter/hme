using hme.Domain.Authentication;
using hme.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Domain.Contracts
{
    public interface IUser : IRepository<User, Guid>
    {
        User FindByEmail(string email);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
