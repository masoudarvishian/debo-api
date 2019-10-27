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
<<<<<<< HEAD
            var typeName = typeof(T).Name;
            if (Repositories.ContainsKey(typeName))
            {
                return Repositories[typeName] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            Repositories.Add(typeName, repo);
            return repo;
        }

        public int SaveChanges() => _context.SaveChanges();

=======
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

>>>>>>> 10e51a8ae0193e5053c099131e6805a6503023a0
        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}