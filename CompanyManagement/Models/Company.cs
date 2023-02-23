namespace CompanyManagement.Models;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PIB { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string CEOFullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
