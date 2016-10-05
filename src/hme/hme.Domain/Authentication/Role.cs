using hme.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hme.Domain.Authentication
{
    public class Role : Audit
    {
        public const string ADMIN = "admin";


        private ICollection<User> users;        

        public Guid Id { get; set; }

        public string Name { get; set; }
        

        public ICollection<User> Users
        {
            get { return users ?? (users = new List<User>()); }
            set { users = value; }
        }        
    }
}
