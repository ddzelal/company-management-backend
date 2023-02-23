using CompanyManagement.Dtos.Invoice;
using CompanyManagement.Helpers;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Services
{
    public class InvoiceService : IInvoiceService
    {
        private DataContext _dataContext;

        public InvoiceService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public List<GetInvoiceResponse> GetInvoices(string CreatorCompanyPIB)
        {
            var data = _dataContext.Invoices
                .Include(i => i.CreatorCompany)
                .Include(i => i.InvoiceItems)
                .Where(i => i.CreatorCompany.PIB == CreatorCompanyPIB)
                .OrderBy(i => i.CreatedAt)
                .ToList();

            return data.Select(d => convertInvoiceToGetInvoiceResponse(d)).ToList();
        }

        public GetInvoiceResponse AddInvoice(AddInvoiceRequest data)
        {
            Company? creatorCompany = _dataContext.Companies.FirstOrDefault(c => c.PIB == data.CreatorCompany);

            if (creatorCompany is null)
            {
                throw new ArgumentException("No Company was found with the provided PIB");
            }

            Invoice invoice = convertAddInvoiceRequestToInvoice(data, creatorCompany);

            _dataContext.Invoices.Add(invoice);
            _dataContext.SaveChanges();

            return convertInvoiceToGetInvoiceResponse(invoice);
        }

        public GetInvoiceResponse EditInvoice(EditInvoiceRequest data)
        {
            var invoice = _dataContext.Invoices.Include(i => i.CreatorCompany).Include(i => i.InvoiceItems).FirstOrDefault(i => i.Id == data.Id);

            if (invoice is null)
            {
                throw new ArgumentException("No Invoice was found");
            }

            invoice.IntendedForCompanyPIB = data.IntendedForCompanyPIB;
            invoice.TotalSum = data.TotalSum;
            invoice.ToBePaidUntil = data.ToBePaidUntil;
            invoice.InvoiceItems = data.InvoiceItems;
            invoice.Type = data.Type;

            _dataContext.Update(invoice);
            _dataContext.SaveChanges();

            return convertInvoiceToGetInvoiceResponse(invoice);
        }

        private Invoice convertAddInvoiceRequestToInvoice(AddInvoiceRequest invoice, Company creatorCompany)
        {
            return new Invoice
            {
                IntendedForCompanyPIB = invoice.IntendedForCompanyPIB,
                InvoiceItems = invoice.InvoiceItems,
                ToBePaidUntil = invoice.ToBePaidUntil,
                CreatorCompany = creatorCompany,
                TotalSum = invoice.TotalSum,
                Type = invoice.Type,
                CreatedAt = new DateTime()
            };
        }

        private GetInvoiceResponse convertInvoiceToGetInvoiceResponse(Invoice invoice)
        {
            return new GetInvoiceResponse
            {
                Id = invoice.Id,
                CreatedAt = invoice.CreatedAt,
                TotalSum = invoice.TotalSum,
                Type = invoice.Type,
                CreatorCompany = invoice.CreatorCompany.PIB,
                IntendedForCompanyPIB = invoice.IntendedForCompanyPIB,
                ToBePaidUntil = invoice.ToBePaidUntil,
                InvoiceItems = invoice.InvoiceItems
            };
        }
    }
}
