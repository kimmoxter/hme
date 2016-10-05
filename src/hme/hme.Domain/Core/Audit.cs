using System;

namespace hme.Domain.Core
{
    public abstract class Audit : Entity
    {
        public DateTime DateCreation { get; set; } = DateTime.Now;

        public DateTime DateModification { get; set; } = DateTime.Now;

        public string UserCreation { get; set; }

        public string UserModification { get; set; }
    }
}
