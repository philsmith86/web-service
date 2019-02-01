using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public class CompanyService : ICompanyService
    {
        private MiniCrmContext _context;
        public CompanyService(MiniCrmContext context)
        {
            _context = context;
        }

        public Task<List<Companies>> GetAllCompanies()
        {
            return Task.FromResult(_context.Companies.ToList());
        }

        public Task<bool> AddCompany(Companies company)
        {
            _context.Companies.Add(company);
            var result = _context.SaveChanges();
            return Task.FromResult(result>0);
        }

        public Task<Companies> GetCompanyById(int id)
        {
            return Task.FromResult(_context.Companies.Single(c => c.Id == id));
        }

        public Task<bool> UpdateCompany(Companies company)
        {
            Companies currentCompany = _context.Companies.Single(c => c.Id == company.Id);
            currentCompany.Name = company.Name;
            currentCompany.Email = company.Email;
            currentCompany.Web = company.Web;
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);

        }

        public Task<bool> DeleteCompany(int id)
        {
            Companies companyToBeDeleted = _context.Companies.Single(c => c.Id == id);
            _context.Companies.Remove(companyToBeDeleted);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);
        }
    }
}
