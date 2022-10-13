using Domain.Entity;

namespace Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task AddCompany(Company company);
        Task<Company> GetCompany(ulong companyPrefix);
    }
}
