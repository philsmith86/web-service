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
            return _companyService.GetAllCompanies();
        }
    }
}