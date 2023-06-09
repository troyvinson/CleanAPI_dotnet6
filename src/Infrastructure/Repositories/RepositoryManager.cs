﻿namespace Infrastructure.Repositories;

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
    private readonly Lazy<IMemberRepository> _memberRepository;
    private readonly Lazy<ITenantRepository> _tenantRepository;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _memberRepository = new Lazy<IMemberRepository>(() => new MemberRepository(repositoryContext));
        _tenantRepository = new Lazy<ITenantRepository>(() => new TenantRepository(repositoryContext));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
    }

    // Provide access to the defined repository class
    public ITenantRepository Tenant => _tenantRepository.Value;
    public IMemberRepository Member => _memberRepository.Value;
    public IUserRepository User => _userRepository.Value;

    // Saves changes to the database
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
