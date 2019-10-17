using DEBO.Core.DomainService;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IBaseRepository<T> _baseRepository;

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> BaseRepository =>
            _baseRepository =
                _baseRepository ?? new BaseRepository<T>(_context);

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