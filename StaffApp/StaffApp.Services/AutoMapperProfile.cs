using AutoMapper;
using StaffApp.Database.Models;
using StaffApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Services
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<CompanyDTO, Company>();
        }
    }
}
