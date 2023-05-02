namespace Infrastructure.Repositories;

/// <summary>
///  Creates instances of defined repository classes and registers them inside 
///  the dependency injection container at once by registering just this class.
/// </summary>
/// <example>
/// Adding to DI container in Startup.cs:
/// <code>builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();</code>
/// </example>
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;

    // Use Lazy to ensure the lazy initialization so that repository instances
    // are only created when accessed the first time and not before that.
    private readonly Lazy<ICompanyRepository> _companyRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
    }

    // Provide access to the defined repository class
    public ICompanyRepository Company => _companyRepository.Value;
    public IEmployeeRepository Employee => _employeeRepository.Value;

    // Saves changes to the database
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
