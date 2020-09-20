using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffApp.Database.Models;
using StaffApp.Services;
using StaffApp.Services.DTO;
using StaffApp.Services.Interfaces.Services;

namespace StaffApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [Route("get/{id?}")]
        public Company Get(long id)
        {
            return companyService.Get(id);
        }

        [HttpPost]
        [Route("search")]
        public List<Company> Search(SearchParameters searchParameters)
        {
            return companyService.Search(searchParameters);
        }

        [HttpPost]
        [Authorize(Policy = "BasicUser")]
        [Route("create")]
        public long Post(CompanyDTO company)
        {
            return companyService.Add(company);
        }

        [HttpPut]
        [Authorize(Policy = "BasicUser")]
        [Route("update")]
        public ActionResult Put(long id, CompanyDTO company)
        {
            companyService.Update(id, company);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = "BasicUser")]
        [Route("delete")]
        public Company Delete(long id)
        {
            return companyService.Remove(id);
        }
    }
}