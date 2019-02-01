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
        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            try
            {
                var result = await _employeeService.GetAllEmployees();
                return Ok(result);

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            try
            {
                var result = await _employeeService.GetEmployeeById(id);
                return Ok(result);

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employees employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.AddEmployee(employee);
                return Ok(result);
            }            
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employees employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("ID Mis-Match");
            }

            if (ModelState.IsValid)
            {
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result);
            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}