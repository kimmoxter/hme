using hme.Domain.Authentication;
using System;

namespace hme.Application.Contracts
{
    public interface IRoleApplicationService : IApplicationService<Role, Guid>
    {
    }
}
