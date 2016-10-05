using hme.Application.Contracts;
using hme.Domain.Authentication;
using hme.Domain.Contracts;
using hme.Domain.Services;
using System;

namespace hme.Application.Providers
{
    public class UserApplicationService : ApplicationService<User, Guid>, IUserApplicationService
    {
        IUser user;

        public UserApplicationService(IUser user, IDomainCommonService domainService)
            : base(user, domainService)
        {
            this.user = user;
        }
    }
}
