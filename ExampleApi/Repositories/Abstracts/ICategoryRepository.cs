using ExampleApi.Core;
using ExampleApi.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ExampleApi.Repositories.Abstracts
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
       
    }
}
