using Application.Commands.Members;
using Application.Commands.Tenants;
using Application.Queries.Members;
using Application.Queries.Tenants;
using Domain.DataTransferObjects;
using Domain.Entities;
using Domain.RequestFeatures;

namespace IntegrationTests;

public class MemberRepositoryTester : IntegrationTestBase
{
    [Test]
    public async Task GetMemberForTenantQuery_GetsMemberFromDatabase()
    {
        // Arrange
        var userId = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        var memberToCreateDto = new MemberForCreationDto { Position = "Test Position", UserId = userId };
        var createMemberResult = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto));
        var member = Mapper.Map<Member>(createMemberResult);

        // Act
        var result = await Mediator.Send(new GetMemberForTenantQuery(tenant.Id, member.Id, TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result!.Position, Is.EqualTo("Test Position"));
            Assert.That(result!.TenantId, Is.EqualTo(tenant.Id));
            Assert.That(result!.Tenant!.Name, Is.EqualTo("Test Tenant"));
            Assert.That(result!.UserId, Is.EqualTo(userId));
        });
    }

    [Test]
    public async Task GetMembersByIdsQuery_GetsMultipleMembersFromDatabase()
    {
        // Arrange
        var userId1 = new Guid().ToString();
        var userId2 = new Guid().ToString();
        var userId3 = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        var memberToCreateDto1 = new MemberForCreationDto { Position = "Test Admin", UserId = userId1 };
        var createMemberResult1 = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto1));
        var member1 = Mapper.Map<Member>(createMemberResult1);

        var memberToCreateDto2 = new MemberForCreationDto { Position = "Test Editor", UserId = userId2 };
        var createMemberResult2 = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto2));
        var member2 = Mapper.Map<Member>(createMemberResult2);

        var memberToCreateDto3 = new MemberForCreationDto { Position = "Test Contributor", UserId = userId3 };
        var createMemberResult3 = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto3));
        var member3 = Mapper.Map<Member>(createMemberResult3);

        var parameters = new MemberParameters() { };

        //Act
        var result = await Mediator.Send(new GetMembersByIdsQuery(tenant.Id, $"{member1.Id},{member2.Id}", parameters, TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Position == member1.Position));
            Assert.That(result.Any(x => x.Position == member2.Position));
            Assert.That(!result.Any(x => x.Position == member3.Position));
        });
    }

    [Test]
    public async Task GetMembersForTenantQuery_GetsMembersFromDatabase()
    {
        // Arrange
        var userId1 = new Guid().ToString();
        var userId2 = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        var memberToCreateDto1 = new MemberForCreationDto { Position = "Test Admin", UserId = userId1 };
        var createMemberResult1 = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto1));
        var member1 = Mapper.Map<Member>(createMemberResult1);

        var memberToCreateDto2 = new MemberForCreationDto { Position = "Test Editor", UserId = userId2 };
        var createMemberResult2 = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto2));
        var member2 = Mapper.Map<Member>(createMemberResult2);

        var parameters = new MemberParameters() { };

        // Act
        var result = await Mediator.Send(new GetMembersForTenantQuery(tenant.Id, parameters, TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Position == member1.Position));
            Assert.That(result.Any(x => x.Position == member2.Position));
        });
    }

    [Test]
    public async Task CreateMemberCommand_AddsMemberToDatabase()
    {
        // Arrange
        var userId = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        // Act
        var memberToCreateDto = new MemberForCreationDto { Position = "Test Position", UserId = userId };
        var createMemberResult = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto));
        var member = Mapper.Map<Member>(createMemberResult);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(member!.Position, Is.EqualTo("Test Position"));
            Assert.That(member!.TenantId, Is.EqualTo(tenant.Id));
            Assert.That(member!.Tenant!.Name, Is.EqualTo("Test Tenant"));
            Assert.That(member!.UserId, Is.EqualTo(userId));
        });
    }

    [Test]
    public async Task DeleteMemberCommand_DeletesMemberFromDatabase()
    {
        // Arrange
        var userId = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        var memberToCreateDto = new MemberForCreationDto { Position = "Test Position", UserId = userId };
        var createMemberResult = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto));
        var member = Mapper.Map<Member>(createMemberResult);

        var parameters = new MemberParameters() { };

        //Act
        Repository.ClearTracking();
        await Mediator.Send(new DeleteMemberCommand(tenant.Id, member.Id, TrackChanges: true));

        // Assert
        var deletedresult = await Mediator.Send(new GetMembersForTenantQuery(tenant.Id, 
            parameters, TrackChanges: false));
        Assert.That(deletedresult.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task UpdateMemberCommand_UpdatesMemberInDatabase()
    {
        // Arrange
        var userId = new Guid().ToString();
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));
        var tenant = Mapper.Map<Tenant>(createResult);

        var memberToCreateDto = new MemberForCreationDto { Position = "Test Position", UserId = userId };
        var createMemberResult = await Mediator.Send(new CreateMemberCommand(tenant.Id, memberToCreateDto));
        var member = Mapper.Map<Member>(createMemberResult);
        var memberToUpdateDto = Mapper.Map<MemberForUpdateDto>(member);

        memberToUpdateDto.Position = "Updated Position";

        // Act
        Repository.ClearTracking();
        await Mediator.Send(new UpdateMemberCommand(tenant.Id, createMemberResult.Id,
            memberToUpdateDto, TenantTrackChanges: false, MemberTrackChanges: true));

        var updatedResult = await Mediator.Send(new GetMemberForTenantQuery(tenant.Id, createMemberResult.Id, TrackChanges: false));

        // Assert
        Assert.That(updatedResult!.Position, Is.EqualTo("Updated Position"));
    }

}
