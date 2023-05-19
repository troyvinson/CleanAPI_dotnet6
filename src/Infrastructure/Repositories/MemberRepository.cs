using Domain.RequestFeatures;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public sealed class MemberRepository : RepositoryBase<Member>, IMemberRepository
{
    public MemberRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<Member?> GetMemberForTenantAsync(Guid tenantId, Guid memberId, bool trackChanges) =>
        await FindByCondition(e => e.TenantId.Equals(tenantId) && e.Id.Equals(memberId), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<IEnumerable<Member>> GetMembersForTenantAsync(Guid tenantId, MemberParameters memberParameters, bool trackChanges) =>
        await FindByCondition(e => e.TenantId.Equals(tenantId), trackChanges)
        .Search(memberParameters.SearchTerm)
        .Sort(memberParameters.OrderBy)
        .ToListAsync();

    public async Task<PagedList<Member>> GetMembersForTenantPagedAsync(Guid tenantId, MemberAndPagingParameters memberParameters, bool trackChanges)
    {
        var members = await FindByCondition(e => e.TenantId.Equals(tenantId), trackChanges)
            .Search(memberParameters.SearchTerm)
            .Sort(memberParameters.OrderBy)
            .ToListAsync();

        return PagedList<Member>
            .ToPagedList(members, memberParameters.PageNumber, memberParameters.PageSize);
    }

    public async Task<IEnumerable<Member>> GetMembersByIdsAsync(Guid tenantId, IEnumerable<Guid> memberIds, MemberParameters memberParameters, bool trackChanges) =>
        await FindByCondition(e => e.TenantId.Equals(tenantId) && memberIds.Contains(e.Id), trackChanges)
        .Search(memberParameters.SearchTerm)
        .Sort (memberParameters.OrderBy)
        .ToListAsync();

    public void CreateMemberForTenant(Guid tenantId, Member member)
    {
        member.TenantId = tenantId;
        Create(member);
    }

    public void DeleteMember(Member member) => Delete(member);


    public override IQueryable<Member> FindByCondition(Expression<Func<Member, bool>> expression, bool trackChanges)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        return !trackChanges ?
          RepositoryContext.Set<Member>().Where(expression)
            .Include(t => t.Tenant)
            .Include(u => u.User)
            .AsNoTracking() :
          RepositoryContext.Set<Member>().Where(expression)
            .Include(t => t.Tenant)
            .Include(u => u.User);
    }


}
