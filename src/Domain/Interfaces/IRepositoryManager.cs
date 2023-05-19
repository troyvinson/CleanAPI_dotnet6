namespace Domain.Interfaces;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    ITenantRepository Tenant { get; }
    IMemberRepository Member { get; }

    Task SaveAsync();
}
