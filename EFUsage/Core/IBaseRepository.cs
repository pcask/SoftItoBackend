
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EFUsage.Core
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Query();
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? customInclude = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? customOrder = null
            );

        TEntity? Get(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include);

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
