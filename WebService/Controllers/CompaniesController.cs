using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebService.Services;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<Companies>>> Get()
        {
            try
            {
                var result = await _companyService.GetAllCompanies();
                return Ok(result);

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> Get(int id)
        {
            try
            {
                var result = await _companyService.GetCompanyById(id);
                return Ok(result);

            } catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Companies company)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.AddCompany(company);
                return Ok(result);
            }
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Companies company)
        {
            if (id != company.Id)
            {
                return BadRequest("ID Mis-Match");
            }

            if (ModelState.IsValid)
            {
                var result = await _companyService.UpdateCompany(company);
                return Ok(result);
            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _companyService.DeleteCompany(id);
                return Ok(result);
            } catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}