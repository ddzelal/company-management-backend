using CompanyManagement.Models.Enums;

namespace CompanyManagement.Models;
public class InvoiceItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double PriceByUnitType { get; set; }
    public string UnitType { get; set; } = "g";
    public double Neto { get; set; }
}
