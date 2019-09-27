using DEBO.Core.DomainService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression)?.AsNoTracking();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
