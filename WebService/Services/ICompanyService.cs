using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public interface ICompanyService
    {
        Task<List<Companies>> GetAllCompanies();
        Task<bool> AddCompany(Companies company);
        Task<Companies> GetCompanyById(int id);
        Task<bool> UpdateCompany(Companies company);
        Task<bool> DeleteCompany(int id);
    }
}
