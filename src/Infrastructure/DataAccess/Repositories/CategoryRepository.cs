using Core.DataAccess.Repositories;
using Core.Entities;
using Infrastructure.DataAccess.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository : MongoDbRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
