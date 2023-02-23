using CompanyManagement.Dtos.Company;
using CompanyManagement.Helpers;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using CompanyManagement.Models.Enums;

namespace CompanyManagement.Services
{
    public class CompanyService : ICompanyService
    {
        private DataContext _dataContext;

        public CompanyService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public List<GetCompanyResponse> GetCompanies(string PIB, string name)
        {
            var data = _dataContext.Companies
                .Where(c => (String.IsNullOrEmpty(PIB) || c.PIB.ToLower().Contains(PIB.ToLower()))
                    && (String.IsNullOrEmpty(name) || c.Name.ToLower().Contains(name.ToLower() ?? String.Empty)))
                .OrderBy(c => c.PIB)
                .ThenBy(c => c.Name)
                .ToList();

            return new List<GetCompanyResponse>(data.Select(d => convertCompanyToGetCompanyResponse(d)));
        }

        public GetCompanyResponse AddCompany(AddCompanyRequest data)
        {
            Company company = convertAddCompanyRequestToCompany(data);

            _dataContext.Companies.Add(company);
            _dataContext.SaveChanges();

            return convertCompanyToGetCompanyResponse(company);
        }

        public GetCompanyResponse EditCompany(EditCompanyRequest data)
        {
            var company = _dataContext.Companies.Find(data.Id);

            if (company is null)
            {
                throw new ArgumentException("No Company was found");
            }

            company.Name = data.Name;
            company.PIB = data.PIB;
            company.PhoneNumber = data.PhoneNumber;
            company.CEOFullName = data.CEOFullName;
            company.Address = data.Address;
            company.Email = data.Email;

            _dataContext.Update(company);
            _dataContext.SaveChanges();
            return convertCompanyToGetCompanyResponse(company);
        }

        public List<string> GetCompanyNames() => _dataContext.Companies.Select(c => c.Name).ToList();

        public double GetBalance(string PIB, DateTime? startDate, DateTime? endDate)
        {
            var invoices = _dataContext.Invoices
                .Where(i => i.CreatorCompany.PIB == PIB
                    && ((startDate == null) || i.CreatedAt > startDate)
                    && ((endDate == null) || i.CreatedAt < endDate));

            double incomingInvoicesSum = invoices
                .Where(i => i.Type == InvoiceType.Incoming)
                .Sum(i => i.TotalSum);

            double outgoingInvoicesSum = invoices
                .Where(i => i.Type == InvoiceType.Outgoing)
                .Sum(i => i.TotalSum);

            return outgoingInvoicesSum - incomingInvoicesSum;
        }


        public List<string> GetCompanyPIBs() => _dataContext.Companies.Select(c => c.PIB).ToList();
        private GetCompanyResponse convertCompanyToGetCompanyResponse(Company company)
        {
            return new GetCompanyResponse
            {
                Id = company.Id,
                Name = company.Name,
                PIB = company.PIB,
                PhoneNumber = company.PhoneNumber,
                Address = company.Address,
                CEOFullName = company.CEOFullName,
                Email = company.Email,
            };
        }

        private Company convertAddCompanyRequestToCompany(AddCompanyRequest data)
        {
            return new Company
            {
                Name = data.Name,
                PhoneNumber = data.PhoneNumber,
                PIB = data.PIB,
                Address = data.Address,
                Email = data.Email,
                CEOFullName = data.CEOFullName
            };
        }
    }
}
