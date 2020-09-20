using StaffApp.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Services
{
    public class SearchParameters
    {
        public string KeyWord { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public Position? EmployeeJobTitles { get; set; }

    }
}
