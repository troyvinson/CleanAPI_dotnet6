using Application.Features.Members.Queries;
using Application.Features.Tenants.Queries;
using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests;

internal class MemberTester : IntegrationTestBase
{
    [Test]
    public async Task GetMemberForTenantQuery_GetsMemberFromDatbase()
    {
        // Arrange
        var memberDto = new MemberDto {
            TenantId = Guid.NewGuid(),
            UserId = Guid.NewGuid().ToString(),
            Position = "Test Position", 
            DateJoined = DateTime.UtcNow
        };
        var member = Mapper.Map<Member>(memberDto);
        Repository.Member.CreateMember(member);
        await Repository.SaveAsync();

        // Act
        var memberFromDb = await Mediator.Send(new GetMemberForTenantQuery(member.TenantId, member.Id, false));

        // Assert
        Assert.That(memberFromDb, Is.Not.Null);
        Assert.That(memberFromDb.Position, Is.EqualTo(memberDto.Position));
    }
}
