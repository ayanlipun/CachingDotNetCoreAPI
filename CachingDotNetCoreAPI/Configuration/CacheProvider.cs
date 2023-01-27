using CachingDotNetCoreAPI.Models;
using CachingDotNetCoreAPI.Service;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using System.Collections;

namespace CachingDotNetCoreAPI.Configuration
{
    public class CacheProvider
    {
        private static readonly SemaphoreSlim getUsersSemaphore = new SemaphoreSlim(1, 1);
        private readonly IMemoryCache _memoryCache;
        public CacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Employee>> GetCachedResponseAsync()
        {
            try
            {
                return await GetSemaphoreCachedResponseAsync(CacheKeys.Employees, getUsersSemaphore);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetSemaphoreCachedResponseAsync(string cacheKey, SemaphoreSlim semaphoreSlim)
        {
            bool isAvaiable = _memoryCache.TryGetValue(cacheKey, out List<Employee>? employees);
            if (isAvaiable) { return employees; }

            try
            {
                await semaphoreSlim.WaitAsync();
                isAvaiable = _memoryCache.TryGetValue(cacheKey, out employees);
                if (isAvaiable) { return employees; }

                employees = EmployeeService.GetListOfEmpoyeesHardCoded();

                var cacheEntry = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(5), SlidingExpiration = TimeSpan.FromMinutes(2), Size = 1024 };
                _memoryCache.Set(cacheKey, employees, cacheEntry);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                semaphoreSlim.Release();
            }
            return employees;
        }
    }
}
