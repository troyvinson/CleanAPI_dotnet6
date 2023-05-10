using Domain.Entities;

namespace Domain.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
    Task<Company> GetCompanyByIdAsync(int companyId, bool trackChanges);
    Task<IEnumerable<Company>> GetCompaniesByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateCompany(Company company);
    void DeleteCompany(Company company);
}
