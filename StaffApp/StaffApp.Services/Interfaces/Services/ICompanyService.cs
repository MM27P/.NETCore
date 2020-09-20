using StaffApp.Database.Models;
using StaffApp.Services.DTO;
using System.Collections.Generic;

namespace StaffApp.Services.Interfaces.Services
{
    public interface ICompanyService
    {
        public long Add(CompanyDTO company);
        public Company Get(long id);
        public void Update(long id, CompanyDTO company);
        public Company Remove(long id);
        public List<Company> Search(SearchParameters searchParameters);
    }
}
