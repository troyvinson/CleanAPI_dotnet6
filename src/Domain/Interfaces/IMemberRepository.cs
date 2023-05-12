using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IMemberRepository
{
    Task<Member?> GetMemberForTenantAsync(int tenantId, int memberId, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersForTenantAsync(int tenantId, MemberParameters memberParameters, bool trackChanges);
    Task<PagedList<Member>> GetMembersForTenantPagedAsync(int tenantId, MemberAndPagingParameters memberParameters, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersByIdsAsync(int tenantId, IEnumerable<int> memberIds, MemberParameters memberParameters, bool trackChanges);
    void CreateMemberForTenant(int tenantId, Member member);
    void DeleteMember(Member member);
}
