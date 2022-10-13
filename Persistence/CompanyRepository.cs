using Domain.Entity;
using Domain.Repositories;

namespace Persistence
{
    public class CompanyRepository : ICompanyRepository
    {
        Dictionary<ulong, Company> _companies;
        public CompanyRepository()
        {
            _companies = new Dictionary<ulong, Company>();
        }

        public async Task AddCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Parameter value [company] can not be null");

            await Task.Run(() => _companies.Add(company.CompanyPrefix, company));
        }

        public async Task<Company> GetCompany(ulong companyPrefix)
        {
            var result = await Task.Run(() => 
                _companies.ContainsKey(companyPrefix) ? _companies[companyPrefix] : null
            );
            return result;
        }
    }
}
