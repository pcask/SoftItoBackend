using ExampleApi.Contexts;
using ExampleApi.Core;
using ExampleApi.Entities;
using ExampleApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ExampleApi.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ExampleDbContext context) : base(context)
        {
        }
    }
}
