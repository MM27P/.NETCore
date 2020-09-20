using StaffApp.Database.Models;
using System.Collections.Generic;

namespace StaffApp.Services.Interfaces.Services
{
    public interface IEmployeeService
    {
        public long Add(Employee employee);
        public Employee Get(long id);
        public void Update(long id, Employee employee);
        public Employee Remove(long id);
        public List<Employee> GetEmployeesByCompany(long companyId);
    }
}
