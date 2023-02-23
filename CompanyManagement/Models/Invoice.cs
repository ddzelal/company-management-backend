using CompanyManagement.Models.Enums;

namespace CompanyManagement.Models;
public class Invoice
{
    public int Id { get; set; }
    public string IntendedForCompanyPIB { get; set; } = null!;
    public Company CreatorCompany { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = new DateTime();
    public DateTime ToBePaidUntil { get; set; }
    public InvoiceType Type { get; set; }
    public double TotalSum { get; set; }

    public ICollection<InvoiceItem> InvoiceItems { get; set;} = new List<InvoiceItem>();
}
