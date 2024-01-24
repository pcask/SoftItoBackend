using EFUsage.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EFUsage.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        protected ExampleDBContext context;
        public BaseRepository()
        {
            context = new ExampleDBContext();
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>();
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
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include = null)
        {
            var query = Query().Where(condition);

            if (include != null)
                query = include(query);

            return query.FirstOrDefault(condition);
        }

        public virtual TEntity Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return entity;
        }
        public virtual TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
        public virtual TEntity Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return entity;
        }
    }
}
