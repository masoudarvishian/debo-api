using System;
using System.Threading.Tasks;

namespace DEBO.Core.DomainService
{
    public interface IUnitOfWork<T> : IDisposable
    {
        IGenericRepository<T> Repository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
