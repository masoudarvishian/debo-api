using DEBO.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> _repositories;

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges() =>
            _context.SaveChanges();

        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        IGenericRepository<T> IUnitOfWork.Repository<T>()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(IGenericRepository<>);
                var repositoryInstance = 
                    Activator
                    .CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}