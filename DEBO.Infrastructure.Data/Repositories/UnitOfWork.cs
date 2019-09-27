using DEBO.Core.DomainService;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContactRepository _contactRepository;

        private ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IContactRepository ContactRepository =>
            _contactRepository = _contactRepository ?? new ContactRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
