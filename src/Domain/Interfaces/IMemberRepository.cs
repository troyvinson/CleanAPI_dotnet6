using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IMemberRepository
{
    Task<PagedList<Member>> GetMembersForTenantAsync(int tenantId, MemberParameters memberParameters, bool trackChanges);
    Task<Member?> GetMemberForTenantAsync(int tenantId, int memberId, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersByIdsAsync(int tenantId, IEnumerable<int> memberIds, bool trackChanges);
    void CreateMemberForTenant(int tenantId, Member member);
    void DeleteMember(Member member);
}
