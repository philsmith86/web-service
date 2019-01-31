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
        public ActionResult<List<Companies>> Get()
        {
            try
            {
                return Ok(_companyService.GetAllCompanies());

            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Companies> Get(int id)
        {
            try
            {
                return Ok(_companyService.GetCompanyById(id));

            } catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Companies company)
        {
            if (ModelState.IsValid)
            {
                _companyService.AddCompany(company);
                return StatusCode(200);
            }
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Companies company)
        {
            if (ModelState.IsValid)
            {
                _companyService.UpdateCompany(company);
                return StatusCode(200);
            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _companyService.DeleteCompany(id);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}