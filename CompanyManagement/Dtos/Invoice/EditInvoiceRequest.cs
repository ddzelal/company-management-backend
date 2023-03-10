using CompanyManagement.Models;
using CompanyManagement.Models.Enums;

namespace CompanyManagement.Dtos.Invoice
{
    public class EditInvoiceRequest
    {
        public int Id { get; set; }
        public string IntendedForCompanyPIB { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime ToBePaidUntil { get; set; }
        public InvoiceType Type { get; set; }
        public double TotalSum { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}