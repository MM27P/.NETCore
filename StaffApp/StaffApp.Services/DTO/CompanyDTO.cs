using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Services.DTO
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public int EstablishYear { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }
    }
}
