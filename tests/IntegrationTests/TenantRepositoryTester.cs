using Application.Commands.Tenants;
using Application.Queries.Tenants;
using AutoMapper.Execution;
using Domain.DataTransferObjects;
using Domain.Entities;

namespace IntegrationTests;

public class TenantRepositoryTester : IntegrationTestBase
{
    [Test]
    public async Task GetTenantQuery_GetsTenantFromDatabase()
    {
        // Arrange
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));

        var tenant = Mapper.Map<Tenant>(createResult);

        // Act
        var result = await Mediator.Send(new GetTenantQuery(tenant.Id, TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result!.Id, Is.EqualTo(tenant.Id));
            Assert.That(result.Name, Is.EqualTo(tenant.Name));
        });
    }

    [Test]
    public async Task GetTenantByIdsQuery_GetsMultipleTenantsFromDatabase()
    {
        // Arrange
        var tenantToCreateDto1 = new TenantForCreationDto { Name = "Test Tenant 1" };
        var createResult1 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto1));
        var tenant1 = Mapper.Map<Tenant>(createResult1);

        var tenantToCreateDto2 = new TenantForCreationDto { Name = "Test Tenant 2" };
        var createResult2 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto2));
        var tenant2 = Mapper.Map<Tenant>(createResult2);

        var tenantToCreateDto3 = new TenantForCreationDto { Name = "Test Tenant 3" };
        var createResult3 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto3));
        var tenant3 = Mapper.Map<Tenant>(createResult3);

        // Act
        var result = await Mediator.Send(new GetTenantsByIdsQuery($"{tenant1.Id},{tenant2.Id}", TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Name == tenant1.Name));
            Assert.That(result.Any(x => x.Name == tenant2.Name));
            Assert.That(!result.Any(x => x.Name == tenant3.Name));
        });
    }

    [Test]
    public async Task GetTenantsQuery_GetsMultipleTenantsFromDatabase()
    {
        // Arrange
        var tenantToCreateDto1 = new TenantForCreationDto { Name = "Test Tenant 1" };
        var createResult1 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto1));
        var tenant1 = Mapper.Map<Tenant>(createResult1);

        var tenantToCreateDto2 = new TenantForCreationDto { Name = "Test Tenant 2" };
        var createResult2 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto2));
        var tenant2 = Mapper.Map<Tenant>(createResult2);

        // Act
        var result = await Mediator.Send(new GetTenantsQuery(TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Name == tenant1.Name));
            Assert.That(result.Any(x => x.Name == tenant2.Name));
        });
    }

    [Test]
    public async Task CreateTenantCommand_AddsTenantToDatabase()
    {
        // Arrange
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };

        // Act
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));

        // Assert
        Assert.That(createResult.Name, Is.EqualTo("Test Tenant"));
    }

    [Test]
    public async Task CreateTenantCollectionCommand_AddsMultipleTenantsToDatabase()
    {
        // Arrange
        var tenantToCreateDto1 = new TenantForCreationDto { Name = "Test Tenant 1" };
        var tenantToCreateDto2 = new TenantForCreationDto { Name = "Test Tenant 2" };

        List<TenantForCreationDto> tenants = new() { tenantToCreateDto1, tenantToCreateDto2 };

        // Act
        var createResult = await Mediator.Send(new CreateTenantCollectionCommand(tenants));

        // Assert
        var result = await Mediator.Send(new GetTenantsQuery(TrackChanges: false));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Name == tenantToCreateDto1.Name));
            Assert.That(result.Any(x => x.Name == tenantToCreateDto2.Name));
        });

    }

    [Test]
    public async Task DeleteTenantCommand_DeletesTenantFromDatabase()
    {
        // Arrange
        var id = Guid.NewGuid();
        var tenant = new Tenant { Id = id, Name = "Test Tenant" };
        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        //Act
        Repository.ClearTracking();
        await Mediator.Send(new DeleteTenantCommand(id, TrackChanges: true));

        // Assert
        var deletedresult = await Mediator.Send(new GetTenantsQuery(TrackChanges: false));
        Assert.That(deletedresult.Count(), Is.EqualTo(0));
    }

    [Test]
    public async Task UpdateTenantCommand_UpdatesTenantInDatabase()
    {
        // Arrange
        var id = Guid.NewGuid();
        var tenant = new Tenant { Id = id, Name = "Test Tenant" };
        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();
        var tenantToUpdateDto = Mapper.Map<TenantForUpdateDto>(tenant);

        tenantToUpdateDto.Name = "Updated Tenant";

        // Act
        Repository.ClearTracking();
        await Mediator.Send(new UpdateTenantCommand(id, tenantToUpdateDto, TrackChanges: true));

        // Assert
        var updatedResult = await Mediator.Send(new GetTenantQuery(id, TrackChanges: false));
        Assert.That(updatedResult!.Name, Is.EqualTo("Updated Tenant"));
    }

}
