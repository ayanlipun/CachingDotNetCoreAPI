using System.ComponentModel.DataAnnotations;

namespace CachingDotNetCoreAPI.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}
