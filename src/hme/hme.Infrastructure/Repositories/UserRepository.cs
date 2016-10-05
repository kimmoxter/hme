using hme.Domain.Authentication;
using hme.Domain.Contracts;
using hme.Infrastructure.Contracts;
using hme.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUser
    {
        public UserRepository(IQueryableUnitOfWork IUnitOfWork)
            : base(IUnitOfWork)
        {
        }

        public User FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
