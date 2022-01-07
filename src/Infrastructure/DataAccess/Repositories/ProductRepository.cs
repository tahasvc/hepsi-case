using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Core.Entities;
using Infrastructure.DataAccess.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : MongoDbRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
