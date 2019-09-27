using System;
using System.Threading.Tasks;

namespace DEBO.Core.DomainService
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
