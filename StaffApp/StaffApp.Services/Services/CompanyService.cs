using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaffApp.Database;
using StaffApp.Database.Models;
using StaffApp.Services.DTO;
using StaffApp.Services.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace StaffApp.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private StaffAppContext staffAppContext;
        private IEmployeeService employeeService;
        private IMapper mapper;
        private SearchParametersFilter searchParametersFilter;

        public CompanyService(StaffAppContext staffAppContext, IEmployeeService employeeService, IMapper mapper, SearchParametersFilter searchParametersFilter)
        {
            this.staffAppContext = staffAppContext;
            this.employeeService = employeeService;
            this.mapper = mapper;
            this.searchParametersFilter = searchParametersFilter;
        }

        public long Add(CompanyDTO company)
        {
            Company newCompany = mapper.Map<Company>(company);
            staffAppContext.Companies.Add(newCompany);
            staffAppContext.SaveChanges();

            //if (newCompany.Employees != null)
            //    AddEmployees(newCompany.Employees);
            return newCompany.Id;
        }

        public Company Get(long id)
        {
            return staffAppContext.Companies.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Company> Search(SearchParameters searchParameters)
        {
            List<Company> searchCompany = staffAppContext.Companies.Include(x=>x.Employees).ToList();

            if (searchParameters.KeyWord != null)
                searchCompany = searchParametersFilter.FiltrByKeyword(searchCompany, searchParameters.KeyWord);
            if (searchParameters.EmployeeDateOfBirthFrom.HasValue)
                searchCompany = searchParametersFilter.FiltryByBirthFrom(searchCompany, searchParameters.EmployeeDateOfBirthFrom.Value);
            if (searchParameters.EmployeeDateOfBirthTo.HasValue)
                searchCompany = searchParametersFilter.FiltryByBirthdayTo(searchCompany, searchParameters.EmployeeDateOfBirthTo.Value);
            if (searchParameters.EmployeeJobTitles.HasValue)
                searchCompany = searchParametersFilter.FiltryByPosition(searchCompany, searchParameters.EmployeeJobTitles.Value);
            return searchCompany;
        }

        public Company Remove(long id)
        {
            Company company = staffAppContext.Companies.Where(x => x.Id == id).FirstOrDefault();

            if (company == null)
                return null;

            staffAppContext.Companies.Remove(company);
            staffAppContext.SaveChanges();
            return company;
        }

        public void Update(long id, CompanyDTO company)
        {
            Company newCompany = mapper.Map<Company>(company);
            newCompany.Id = id;
            Company companyToUpdate = staffAppContext.Companies.Where(x => x.Id == id).Include(x => x.Employees).FirstOrDefault();
            staffAppContext.Entry(companyToUpdate).CurrentValues.SetValues(newCompany);
            staffAppContext.SaveChanges();

            if (companyToUpdate == null)
                return;

            if (newCompany.Employees != null)
                if (companyToUpdate.Employees == null || companyToUpdate.Employees.Count() == 0)
                {
                    AddEmployees(newCompany.Employees);
                }
                else
                {
                    UpdateUserList(companyToUpdate.Employees.ToList(), newCompany.Employees.ToList(), id);
                }          
        }

        private void AddEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employeeService.Add(employee);
                staffAppContext.SaveChanges();
            }
        }

        private void UpdateUserList(List<Employee> oldList, List<Employee> newList, long companyId)
        {

            Dictionary<Employee, Employee> employeesToUpdate = new Dictionary<Employee, Employee>();

            foreach (var employee in newList)
            {
                Employee oldEmployee = oldList.Where(x => x.Name.Equals(employee.Name) && x.LastName.Equals(employee.LastName)).FirstOrDefault();
                if (oldEmployee != null)
                {
                    employeesToUpdate.Add(oldEmployee, employee);
                    employeeService.Update(oldEmployee.Id, employee);
                }
                else
                {
                    employee.CompanyId = companyId;
                    employeeService.Add(employee);
                }
            }

            foreach (var oldEmployee in oldList)
            {
                if (!employeesToUpdate.Keys.Contains(oldEmployee))
                {
                    employeeService.Remove(oldEmployee.Id);
                }
            }

            staffAppContext.SaveChanges();
        }
    }
}
