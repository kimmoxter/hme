using System.Data.Entity;
using System.Threading.Tasks;
using hme.Domain.Core;

namespace hme.Infrastructure.Contracts
{
    public interface IQueryableUnitOfWork 
        : IUnitOfWork
    {
        IDbSet<T> CreateSet<T>() where T : class;

        Task Update<T>(T olderEntity, T newEntity) where T : class;
    }
}