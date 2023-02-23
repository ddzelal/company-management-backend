using CompanyManagement.Dtos.Company;
using CompanyManagement.Dtos.Invoice;
using CompanyManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }

        [HttpGet(Name = "GetInvoices")]
        public ActionResult<List<GetInvoiceResponse>> GetInvoices(string creatorCompanyPIB) =>
            Ok(this._invoiceService.GetInvoices(creatorCompanyPIB));

        [HttpPost(Name = "AddInvoice")]
        public ActionResult<GetInvoiceResponse> AddInvoice([FromBody] AddInvoiceRequest data)
            => Ok(this._invoiceService.AddInvoice(data));

        [HttpPut(Name = "EditInvoice")]
        public ActionResult<GetInvoiceResponse> EditInvoice(EditInvoiceRequest data)
            => Ok(this._invoiceService.EditInvoice(data));
    }
}
