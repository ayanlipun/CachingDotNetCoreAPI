using CachingDotNetCoreAPI.Models;

namespace CachingDotNetCoreAPI.Service
{
    public static class EmployeeService
    {
        public static List<Employee> GetListOfEmpoyeesHardCoded()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                     FirstName ="Harry",
                     LastName="Porter",
                      EmailId="harryporter@gmail.com"
                },
            new Employee()
            {
                FirstName = "David",
                LastName = "Haans",
                EmailId = "davidhaans@gmail.com"
            },

             new Employee()
            {
                FirstName = "Michle",
                LastName = "Zensar",
                EmailId = "michlezensar@gmail.com"
            }
        };
            return employees;
        }
    }
}
