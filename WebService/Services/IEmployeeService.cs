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
        List<EmployeeDto> GetAllEmployees();
        void AddEmployee(Employees employee);
        EmployeeDto GetEmployeeById(int id);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(int id);
    }
}
