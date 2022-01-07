#nullable enable
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Common.Models;
using Core.Entities;

namespace Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async void Set(string key, string value, DistributedCacheEntryOptions? options = null)
        {
            options ??= new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(5) };

            await distributedCache.SetStringAsync(key, value, options);
        }

        public async Task<string> Get(string key)
        {
            return await distributedCache.GetStringAsync(key);
        }
    }
}
