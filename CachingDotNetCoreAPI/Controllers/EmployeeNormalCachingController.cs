using CachingDotNetCoreAPI.Models;
using CachingDotNetCoreAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CachingDotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeNormalCachingController : ControllerBase
    {
        public IMemoryCache _memoryCache;
        public EmployeeNormalCachingController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [Route("getEmployees")]
        public IActionResult GetAllEmployeeAsyn()
        {
            if (!_memoryCache.TryGetValue(CacheKeys.Employees, out List<Employee>? employees))
            {
                employees = EmployeeService.GetListOfEmpoyeesHardCoded();

                var cacheEntry = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024
                };
                _memoryCache.Set(CacheKeys.Employees, employees, cacheEntry);
            }
            return Ok(employees);
        }      
    }
}
