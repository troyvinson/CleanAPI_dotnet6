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
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ITenantRepository> _tenantRepository;
    private readonly Lazy<IMemberRepository> _memberRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _memberRepository = new Lazy<IMemberRepository>(() => new MemberRepository(repositoryContext));
        _tenantRepository = new Lazy<ITenantRepository>(() => new TenantRepository(repositoryContext));
    }

    // Provide access to the defined repository class
    public IUserRepository User => _userRepository.Value;
    public ITenantRepository Tenant => _tenantRepository.Value;
    public IMemberRepository Member => _memberRepository.Value;

    // Saves changes to the database
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
