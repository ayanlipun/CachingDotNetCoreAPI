using CachingDotNetCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CachingDotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCacheLockController : ControllerBase
    {
        public IMemoryCache _memoryCache;
        public EmployeeCacheLockController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [Route("getEmployees")]
        public IActionResult GetAllEmployeeAsyn()
        {
            try
            {
                var employees =  _memoryCache.getCahchedResonse
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
