using DEBO.Core.DomainService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> Repositories { get; set; }

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Repositories = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (Repositories.ContainsKey(type))
            {
                return Repositories[type] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            Repositories.Add(type, repo);
            return repo;
        }

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}