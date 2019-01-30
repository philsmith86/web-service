using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public interface ICompanyService
    {
        List<Companies> GetAllCompanies();
        void AddCompany(Companies company);
        Companies GetCompanyById(int id);
        void UpdateCompany(Companies company);
        void DeleteCompany(int id);
    }
}
