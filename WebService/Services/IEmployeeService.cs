using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees();
        void AddEmployee(Employees employee);
        Employees GetEmployeeById(int id);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(int id);
    }
}
