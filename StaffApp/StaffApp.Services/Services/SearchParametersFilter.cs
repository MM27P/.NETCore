using StaffApp.Database.Models;
using StaffApp.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StaffApp.Services.Services
{
    public class SearchParametersFilter
    {
        public List<Company> FiltrByKeyword(List<Company> companies, string keyword)
        {
            return companies.Where(x => x.Name.Contains(keyword) || x.Employees.Any(y => y.Name.Contains(keyword) || y.LastName.Contains(keyword))).ToList();
        }

        public List<Company> FiltryByBirthFrom(List<Company> companies, DateTime birthFrom)
        {
            return companies.Where(x => x.Employees.Any(y => y.Birthday >= birthFrom)).ToList();
        }

        public List<Company> FiltryByBirthdayTo(List<Company> companies, DateTime birthTo)
        {
            return companies.Where(x => x.Employees.Any(y => y.Birthday <= birthTo)).ToList();
        }

        public List<Company> FiltryByPosition(List<Company> companies, Position position)
        {
            return companies.Where(x => x.Employees.Any(y => y.Position.Equals(position))).ToList();
        }
    }
}
