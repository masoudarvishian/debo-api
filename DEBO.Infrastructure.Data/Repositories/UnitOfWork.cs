using DEBO.Core.DomainService;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IContactRepository _contactRepository;
        private ICategoryRepository _categoryRepository;

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IContactRepository ContactRepository =>
            _contactRepository =
                _contactRepository ?? new ContactRepository(_context);

        public ICategoryRepository CategoryRepository =>
            _categoryRepository =
                _categoryRepository ?? new CategoryRepository(_context);

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