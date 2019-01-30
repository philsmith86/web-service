using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Employees> GetAllEmployees()
        {
            return _context.Employees.Include(e => e.Company).ToList();
        }

        public void AddEmployee(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employees GetEmployeeById(int id)
        {
            return _context.Employees.Single(c => c.Id == id);
        }

        public void UpdateEmployee(Employees employee)
        {
            Employees currentEmployee = GetEmployeeById(employee.Id);
            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;
            currentEmployee.Telephone = employee.Telephone;
            currentEmployee.Email = employee.Email;
            currentEmployee.CompanyId = employee.CompanyId;
            _context.SaveChanges();

        }

        public void DeleteEmployee(int id)
        {
            Employees employeeToBeDeleted = GetEmployeeById(id);
            _context.Employees.Remove(employeeToBeDeleted);
            _context.SaveChanges();
        }
    }
}
