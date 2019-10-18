using DEBO.Core.DomainService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>()
                .AsNoTracking();
        }

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>()
                .Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>()
                .Update(entity);
        }

        public virtual IQueryable<TEntity> FindByCondition(
            Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>()
                .Where(expression)
                ?.AsNoTracking();
        }

        public virtual void Delete(TEntity entity)
        {
            // _context.Set<TEntity>().Remove(entity);
            throw new NotImplementedException();
        }
    }
}