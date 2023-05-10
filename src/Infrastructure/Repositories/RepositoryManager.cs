namespace Infrastructure.Repositories;

/// <summary>
///  Creates instances of defined repository classes and registers them inside 
///  the dependency injection container all at once by registering just this class.
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
    private readonly Lazy<IRoleRepository> _roleRepository;
    private readonly Lazy<IRoleTypeRepository> _roleTypeRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IUserRoleRepository> _userRoleRepository;
    private readonly Lazy<ITenantRepository> _tenantRepository;
    private readonly Lazy<IMemberRepository> _memberRepository;
    private readonly Lazy<IMemberRoleRepository> _memberRoleRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _userRoleRepository = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(repositoryContext));
        _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
        _roleTypeRepository = new Lazy<IRoleTypeRepository>(() => new RoleTypeRepository(repositoryContext));
        _memberRepository = new Lazy<IMemberRepository>(() => new MemberRepository(repositoryContext));
        _memberRoleRepository = new Lazy<IMemberRoleRepository>(() => new MemberRoleRepository(repositoryContext));
        _tenantRepository = new Lazy<ITenantRepository>(() => new TenantRepository(repositoryContext));
    }

    // Provide access to the defined repository class
    public ICompanyRepository Company => _companyRepository.Value;
    public IEmployeeRepository Employee => _employeeRepository.Value;
    public IUserRepository User => _userRepository.Value;
    public IUserRoleRepository UserRole => _userRoleRepository.Value;
    public IRoleRepository Role => _roleRepository.Value;
    public IRoleTypeRepository RoleType => _roleTypeRepository.Value;
    public ITenantRepository Tenant => _tenantRepository.Value;
    public IMemberRepository Member => _memberRepository.Value;
    public IMemberRoleRepository MemberRole => _memberRoleRepository.Value;

    // Saves changes to the database
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
