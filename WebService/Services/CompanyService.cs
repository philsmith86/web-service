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

        public List<Companies> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public void AddCompany(Companies company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public Companies GetCompanyById(int id)
        {
            return _context.Companies.Single(c => c.Id == id);
        }

        public void UpdateCompany(Companies company)
        {
            Companies currentCompany = GetCompanyById(company.Id);
            currentCompany.Name = company.Name;
            currentCompany.Email = company.Email;
            currentCompany.Web = company.Web;
            _context.SaveChanges();

        }

        public void DeleteCompany(int id)
        {
            Companies companyToBeDeleted = GetCompanyById(id);
            _context.Companies.Remove(companyToBeDeleted);
            _context.SaveChanges();
        }
    }
}
