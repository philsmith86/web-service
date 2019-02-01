using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Dto;
using WebService.Models;

namespace WebService.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<bool> AddEmployee(Employees employee);
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<bool> UpdateEmployee(Employees employee);
        Task<bool> DeleteEmployee(int id);
    }
}
