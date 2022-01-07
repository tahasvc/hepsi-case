using Core.DataAccess.Repositories;
using Infrastructure.DataAccess.Configuration;
using Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
            });

            #region Dependency Injection

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IExceptionRepository, ExceptionRepository>();

            #endregion


            return services;
        }
    }
}
