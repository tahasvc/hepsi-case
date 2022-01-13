using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Middleware;
using Application.Services;
using Microsoft.AspNetCore.Builder;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            #region Dependency Injection

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = "localhost:6379";
                action.InstanceName = "";
            });
            services.AddScoped<ICacheService, CacheService>();
            #endregion


            return services;
        }

        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
