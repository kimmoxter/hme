using hme.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hme.Application.Contracts
{
    public interface IUserApplicationService : IApplicationService<User, Guid>
    {
    }
}
