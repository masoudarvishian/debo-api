using DEBO.Core.DomainService;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IGenericRepository<T> _repository;

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository =>
            _repository =
                _repository ?? new GenericRepository<T>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges() =>
            _context.SaveChanges();

        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}