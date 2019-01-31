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

        public List<EmployeeDto> GetAllEmployees()
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
                });
            return query.ToList(); ;

        }

        public void AddEmployee(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public EmployeeDto GetEmployeeById(int id)
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

            return query; ;
        }

        private Employees GetById(int id)
        {
            return _context.Employees.Single(c => c.Id == id);
        }

        public void UpdateEmployee(Employees employee)
        {
            Employees currentEmployee = GetById(employee.Id);
            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;
            currentEmployee.Telephone = employee.Telephone;
            currentEmployee.Email = employee.Email;
            currentEmployee.CompanyId = employee.CompanyId;
            _context.SaveChanges();

        }

        public void DeleteEmployee(int id)
        {
            Employees employeeToBeDeleted = GetById(id);
            _context.Employees.Remove(employeeToBeDeleted);
            _context.SaveChanges();
        }
    }
}
