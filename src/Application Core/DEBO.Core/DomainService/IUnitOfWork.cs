using System.Threading.Tasks;

namespace DEBO.Core.DomainService
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
