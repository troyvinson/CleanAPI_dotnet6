using Application.Commands.Tenants;
using Application.Notifications;
using Application.Queries.Tenants;
using Domain.DataTransferObjects;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests;

[TestFixture]
public class TenantRepositoryTester : IntegrationTestBase
{
    [Test]
    public async Task CreateTenant_AddsTenantToDatabase()
    {
        // Arrange
        var tenantToCreateDto = new TenantForCreationDto { Name = "Test Tenant" };

        // Act
        var createResult = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto));

        // Assert
        Assert.That(await Context.Tenants.CountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetTenantByIdAsync_GetsTenantFromDatabase()
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
    public async Task GetTenantsAsync_GetsTenantsFromDatabase()
    {
        // Arrange
        var tenantToCreateDto1 = new TenantForCreationDto { Name = "Test Tenant 1" };
        var createResult1 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto1));
        var tenant1 = Mapper.Map<Tenant>(createResult1);

        var tenantToCreateDto2 = new TenantForCreationDto { Name = "Test Tenant 2" };
        var createResult2 = await Mediator.Send(new CreateTenantCommand(tenantToCreateDto2));
        var tenant2 = Mapper.Map<Tenant>(createResult1);

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
    public async Task DeleteTenant_DeletesTenantFromDatabase()
    {
        // Arrange
        var id = Guid.NewGuid();
        var tenant = new Tenant { Id = id, Name = "Test Tenant" };
        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        //Act
        Repository.ClearTracking();
        await Mediator.Send(new DeleteTenantCommand(id, TrackChanges: false));

        // Assert
        var deletedresult = await Repository.Tenant.GetTenantsAsync(trackChanges: false);
        Assert.That(deletedresult.Count(), Is.EqualTo(0));
    }
}
