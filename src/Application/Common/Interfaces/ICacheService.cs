#nullable enable
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Common.Interfaces
{
    public interface ICacheService
    {
        void Set(string key, string value, DistributedCacheEntryOptions? options = null);
        Task<string> Get(string key);
    }
}
