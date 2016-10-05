using hme.Application.Contracts;
using hme.Domain.Authentication;
using System;
using hme.Domain.Core;
using hme.Domain.Services;

namespace hme.Application.Providers
{
    public class RoleApplicationService : ApplicationService<Role, Guid>, IRoleApplicationService
    {
        public RoleApplicationService(IRepository<Role, Guid> repository, IDomainCommonService domainService) 
            : base(repository, domainService)
        {
        }
    }
}
