using CompanyManagement.Dtos.Company;
using CompanyManagement.Dtos.Invoice;

namespace CompanyManagement.Services.Interfaces
{
    public interface IInvoiceService
    {
        public List<GetInvoiceResponse> GetInvoices(string CreatorCompanyPIB);
        public GetInvoiceResponse AddInvoice(AddInvoiceRequest data);
        public GetInvoiceResponse EditInvoice(EditInvoiceRequest data);
    }
}
