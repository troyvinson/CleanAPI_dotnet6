namespace Domain.Interfaces;

public interface IRepositoryManager
{
    IMemberRepository Member { get; }
    ITenantRepository Tenant { get; }
    IUserRepository User { get; }

    Task SaveAsync();
}
