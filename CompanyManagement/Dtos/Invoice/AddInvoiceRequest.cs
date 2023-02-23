using CompanyManagement.Models;
using CompanyManagement.Models.Enums;

namespace CompanyManagement.Dtos.Invoice
{
    public class AddInvoiceRequest
    {
        public string IntendedForCompanyPIB { get; set; } = null!;
        public string CreatorCompany { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime ToBePaidUntil { get; set; }
        public InvoiceType Type { get; set; }
        public double TotalSum { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
