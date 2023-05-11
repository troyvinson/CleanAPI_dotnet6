using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembersForTenantAsync(int tenantId, bool trackChanges);
    Task<PagedList<Member>> GetMembersForTenantPagedAsync(int tenantId, MemberParameters memberParameters, bool trackChanges);
    Task<Member?> GetMemberForTenantAsync(int tenantId, int memberId, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersByIdsAsync(int tenantId, IEnumerable<int> memberIds, bool trackChanges);
    void CreateMemberForTenant(int tenantId, Member member);
    void DeleteMember(Member member);
}
