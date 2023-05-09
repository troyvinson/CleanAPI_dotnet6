using Domain.RequestFeatures;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class MemberRepository : RepositoryBase<Member>, IMemberRepository
{
    public MemberRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<PagedList<Member>> GetMembersForTenantAsync(int tenantId, MemberParameters memberParameters, bool trackChanges)
    {
        memberParameters.SearchTerm ??= string.Empty;

        var members = await FindByCondition(e => e.TenantId.Equals(tenantId), trackChanges)
            .Search(memberParameters.SearchTerm)
            .OrderBy(e => e.Id)
            .ToListAsync();

        return PagedList<Member>
            .ToPagedList(members, memberParameters.PageNumber, memberParameters.PageSize);
    }

    public async Task<Member?> GetMemberForTenantAsync(int tenantId, int memberId, bool trackChanges) =>
        await FindByCondition(e => e.TenantId.Equals(tenantId) && e.Id.Equals(memberId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateMemberForTenant(int tenantId, Member member)
    {
        member.TenantId = tenantId;
        Create(member);
    }

    public void DeleteMember(Member member) => Delete(member);
}
