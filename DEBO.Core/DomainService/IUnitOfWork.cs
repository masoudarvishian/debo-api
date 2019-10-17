using System;
using System.Threading.Tasks;

namespace DEBO.Core.DomainService
{
    public interface IUnitOfWork<T> : IDisposable
    {
        IBaseRepository<T> BaseRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
