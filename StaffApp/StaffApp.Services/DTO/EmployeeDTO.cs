using StaffApp.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Services.DTO
{
    public class EmployeeDTO
    {


        public string Name { get; set; }

        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Position Position { get; set; }

        private string PositionName { get; set; }
    }
}
