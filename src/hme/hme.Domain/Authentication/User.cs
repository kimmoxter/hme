using hme.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hme.Domain.Authentication
{
    public class User : Audit
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public IList<Role> Roles { get; set; }

        public bool HasRole
        {
            get { return this.Roles?.Count > 0; }
        }
    }
}
