using StaffApp.Database;
using StaffApp.Database.Models;
using StaffApp.Services.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace StaffApp.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private StaffAppContext staffAppContext;

        public EmployeeService(StaffAppContext staffAppContext)
        {
            this.staffAppContext = staffAppContext;
        }
        public long Add(Employee employee)
        {
            staffAppContext.Employees.Add(employee);
            staffAppContext.SaveChanges();
            return employee.Id;
        }

        public Employee Get(long id)
        {
            return staffAppContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Employee> GetEmployeesByCompany(long companyId)
        {
            return staffAppContext.Employees.Where(x => x.CompanyId == companyId).ToList();
        }

        public Employee Remove(long id)
        {
            Employee employee = staffAppContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
                return null;

            staffAppContext.Employees.Remove(employee);
            staffAppContext.SaveChanges();
            return employee;
        }

        public void Update(long id, Employee employee)
        {
            Employee employeeToUpdate = staffAppContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            employee.Id = id;
            employee.CompanyId = employeeToUpdate.CompanyId;
            if (employeeToUpdate == null)
                return;

            staffAppContext.Entry(employeeToUpdate).CurrentValues.SetValues(employee);
            staffAppContext.SaveChanges();
        }
    }
}
