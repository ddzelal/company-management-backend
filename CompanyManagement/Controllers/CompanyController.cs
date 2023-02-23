using CompanyManagement.Dtos.Company;
using CompanyManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet(Name = "GetCompanies")]
        public ActionResult<List<GetCompanyResponse>> GetCompanies(string? PIB, string? name) =>
            Ok(this._companyService.GetCompanies(PIB ?? string.Empty, name ?? string.Empty));

        [HttpGet("Names")]
        public ActionResult<List<string>> GetCompanyNames() =>
            Ok(this._companyService.GetCompanyNames());
            
        [HttpGet("PIBs")]
        public ActionResult<List<string>> GetCompanyPIBs() =>
            Ok(this._companyService.GetCompanyPIBs());

        [HttpGet("Balance")]
        public ActionResult<double> GetBalance(string companyPIB, DateTime? startDate, DateTime? endDate) =>
            Ok(this._companyService.GetBalance(companyPIB, startDate, endDate));

        [HttpPost(Name = "AddCompany")]
        public ActionResult<GetCompanyResponse> AddCompany(AddCompanyRequest data)
            => Ok(this._companyService.AddCompany(data));

        [HttpPut(Name = "EditCompany")]
        public ActionResult<GetCompanyResponse> EditCompany(EditCompanyRequest data)
            => Ok(this._companyService.EditCompany(data));
    }
}