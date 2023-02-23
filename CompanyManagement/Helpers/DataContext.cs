using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CompanyManagement.Helpers;
public class DataContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;

    protected readonly IConfiguration configuration;
    public DataContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        string connectionString = configuration.GetConnectionString("CompanyDb");
        Console.WriteLine(connectionString, "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSs");
        options.UseSqlServer(connectionString);

    }
}
