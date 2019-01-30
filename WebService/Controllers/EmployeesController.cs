using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebService.Services;
using WebService.Models;
using WebService.Dto;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        private ICompanyService _companyService;

        public EmployeesController(IEmployeeService employeeService, ICompanyService companyService)
        {
            _employeeService = employeeService;
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>> Get()
        {
            return _employeeService.GetAllEmployees();
        }
    }
}