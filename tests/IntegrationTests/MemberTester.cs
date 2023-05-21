using Application.Features.Members.Commands;
using Application.Features.Members.Queries;
using Application.Features.Tenants.Commands;
using Domain.DataTransferObjects;
using Domain.Entities;

namespace IntegrationTests;

internal class MemberTester : IntegrationTestBase
{
    [Test]
    public async Task GetMemberForTenantQuery_GetsMemberFromDatbase()
    {
        // Arrange
        var userDto = new UserForRegistrationDto
        {
            GivenName = "Test",
            Surname = "User",
            Email = "testuser@example.com",
            Password = "Pa$$w0rd1234",
            PhoneNumber = "1234567890",
            UserName = "testuser"
        };
        var user = Mapper.Map<User>(userDto);
        _ = await UserManager.CreateAsync(user, userDto.Password);

        var tenantDto = new TenantForCreationDto
        {
            Name = "Test Tenant",
        };
        var tenantResult = await Mediator.Send(new CreateTenantCommand(tenantDto));

        var memberDto = new MemberForCreationDto
        {
            TenantId = tenantResult.Id,
            UserId = user.Id,
            Position = "Test Position",
            DateJoined = DateTimeOffset.Now
        };
        var member = await Mediator.Send(new CreateMemberCommand(memberDto.TenantId, memberDto));

        // Act
        var memberFromDb = await Mediator.Send(new GetMemberForTenantQuery(member.TenantId, member.Id, false));

        // Assert
        Assert.That(memberFromDb, Is.Not.Null);
        Assert.That(memberFromDb.UserId, Is.EqualTo(user.Id));
        Assert.That(memberFromDb.Position, Is.EqualTo(memberDto.Position));
    }
}
