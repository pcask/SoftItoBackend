using ExampleApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ExampleApi.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        protected ExampleDbContext _context;
        public BaseRepository(ExampleDbContext context)
        {
            _context = context;
        }

        protected IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            )
        {
            var query = Query();

            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public virtual TEntity? Get(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include = null
            )
        {
            var query = Query();

            if (include != null)
                query = include(query);

            return query.FirstOrDefault(condition);
        }

        public virtual TEntity Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
            return entity;
        }
    }
}
