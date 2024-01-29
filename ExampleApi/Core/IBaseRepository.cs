using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ExampleApi.Core
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            );

        TEntity? Get(
           Expression<Func<TEntity, bool>> condition,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, dynamic>>? include = null
           );

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
