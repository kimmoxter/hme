using System;
using System.Threading;
using System.Threading.Tasks;

namespace hme.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();

        Task CommitAsync(CancellationToken token);
        
        void RollBack();
    }
}
