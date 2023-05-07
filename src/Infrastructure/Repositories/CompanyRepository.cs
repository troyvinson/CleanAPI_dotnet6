using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Company?> GetCompanyByIdAsync(int companyId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<Company>> GetCompaniesByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToListAsync();

    public void CreateCompany(Company company) => base.Create(company);

    public void DeleteCompany(Company company) => base.Delete(company);
}
