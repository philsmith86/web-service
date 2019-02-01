using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Dto;
using WebService.Models;

namespace WebService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private MiniCrmContext _context;
        public EmployeeService(MiniCrmContext context)
        {
            _context = context;
        }

        public Task<List<EmployeeDto>> GetAllEmployees()
        {
            var query = _context.Employees
                .Join(_context.Companies,
                e => e.CompanyId,
                c => c.Id,
                (e,c) => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Telephone = e.Telephone,
                    Email = e.Email,
                    CompanyId = e.CompanyId,
                    CompanyName =c.Name
                }).ToList();
            return Task.FromResult(query);

        }

        public Task<bool> AddEmployee(Employees employee)
        {
            _context.Employees.Add(employee);
            var result = _context.SaveChanges();
            return Task.FromResult(result>0);
        }

        public Task<EmployeeDto> GetEmployeeById(int id)
        {
            var query = _context.Employees
                .Join(_context.Companies,
                e => e.CompanyId,
                c => c.Id,
                (e, c) => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Telephone = e.Telephone,
                    Email = e.Email,
                    CompanyId = e.CompanyId,
                    CompanyName = c.Name
                })
                .Where(e=>e.Id==id)
                .Single();

            return Task.FromResult(query); ;
        }

        private Employees GetById(int id)
        {
            return _context.Employees.Single(c => c.Id == id);
        }

        public Task<bool> UpdateEmployee(Employees employee)
        {
            Employees currentEmployee = GetById(employee.Id);
            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;
            currentEmployee.Telephone = employee.Telephone;
            currentEmployee.Email = employee.Email;
            currentEmployee.CompanyId = employee.CompanyId;
            var result = _context.SaveChanges();
            return Task.FromResult(result>0);
        }

        public Task<bool> DeleteEmployee(int id)
        {
            Employees employeeToBeDeleted = GetById(id);
            _context.Employees.Remove(employeeToBeDeleted);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);
        }
    }
}
