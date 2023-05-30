namespace Domain.Interfaces;

public interface IRepositoryManager
{
    ITenantRepository Tenant { get; }
    IMemberRepository Member { get; }

    Task SaveAsync();
}
