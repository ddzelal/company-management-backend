using CompanyManagement.Dtos.Company;
using CompanyManagement.Helpers;

namespace CompanyManagement.Services.Interfaces;
public interface ICompanyService
{
    public List<GetCompanyResponse> GetCompanies(string PIB, string name);
    public GetCompanyResponse AddCompany(AddCompanyRequest data);
    public GetCompanyResponse EditCompany(EditCompanyRequest data);
    public List<string> GetCompanyNames();
    public List<string> GetCompanyPIBs();
    public double GetBalance(string PIB, DateTime? startDate, DateTime? endDate);
}
