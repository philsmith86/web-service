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
            try
            {
                return Ok(_employeeService.GetAllEmployees());

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get(int id)
        {
            try
            {
                return Ok(_employeeService.GetEmployeeById(id));

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Employees employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                return StatusCode(200);
            }            
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employees employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return StatusCode(200);
            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}