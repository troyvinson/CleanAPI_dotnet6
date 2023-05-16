﻿using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IMemberRepository
{
    Task<Member?> GetMemberForTenantAsync(Guid tenantId, Guid memberId, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersForTenantAsync(Guid tenantId, MemberParameters memberParameters, bool trackChanges);
    Task<PagedList<Member>> GetMembersForTenantPagedAsync(Guid tenantId, MemberAndPagingParameters memberParameters, bool trackChanges);
    Task<IEnumerable<Member>> GetMembersByIdsAsync(Guid tenantId, IEnumerable<Guid> memberIds, MemberParameters memberParameters, bool trackChanges);
    void CreateMemberForTenant(Guid tenantId, Member member);
    void DeleteMember(Member member);
}
