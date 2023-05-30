using Application.Features.Tenants.Commands;
using Application.Features.Tenants.Queries;
using Domain.DataTransferObjects;
using Domain.Entities;
using Domain.RequestFeatures;

namespace IntegrationTests;

public class TenantTester : IntegrationTestBase
{
    [Test]
    public async Task GetTenantQuery_GetsTenantFromDatabase()
    {
        // Arrange
        var tenantDto = new TenantDto { Name = "Test Tenant" };
        var tenant = Mapper.Map<Tenant>(tenantDto);

        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        // Act
        var tenantFromDb = await Mediator.Send(new GetTenantQuery(tenant.Id, false));

        // Assert
        Assert.That(tenantFromDb, Is.Not.Null);
        Assert.That(tenantFromDb.Name, Is.EqualTo(tenantDto.Name));
    }

    [Test]
    public async Task GetTenantsQuery_GetsTenantListFromDatabase()
    {
        // Arrange
        var tenantDto = new TenantDto { Name = "Test Tenant" };
        var tenant = Mapper.Map<Tenant>(tenantDto);

        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        // Act
        var tenantsFromDb = await Mediator.Send(new GetTenantsQuery(new TenantParameters { }, false));

        // Assert
        Assert.That(tenantsFromDb, Is.Not.Null);
        Assert.That(tenantsFromDb.Count, Is.EqualTo(1));
        Assert.That(tenantsFromDb.FirstOrDefault()?.Name, Is.EqualTo(tenantDto.Name));
    }

    [Test]
    public async Task GetTenantsByIdsQuery_GetsTenantListFromDatabase()
    {
        // Arrange
        var tenantDto = new TenantDto { Name = "Test Tenant" };
        var tenant = Mapper.Map<Tenant>(tenantDto);

        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        // Act
        var tenantsFromDb = await Mediator.Send(new GetTenantsByIdsQuery(tenant.Id.ToString(), new TenantParameters { }, false));

        // Assert
        Assert.That(tenantsFromDb.Count, Is.EqualTo(1));
        Assert.That(tenantsFromDb.FirstOrDefault()?.Name, Is.EqualTo(tenantDto.Name));
    }

    [Test]
    public async Task CreateTenantCommand_AddsTenantToDatabase()
    {
        // Arrange
        var tenantForCreationDto = new TenantForCreationDto { Name = "Test Tenant" };

        // Act
        var tenant = await Mediator.Send(new CreateTenantCommand(tenantForCreationDto));

        // Assert
        Assert.That(tenant, Is.Not.Null);
        Assert.That(tenant.Name, Is.EqualTo(tenantForCreationDto.Name));
    }

    [Test]
    public async Task UpdateTenantCommand_UpdatesTenantInDatabase()
    {
        // Arrange
        var tenantDto = new TenantDto { Name = "Test Tenant" };
        var tenant = Mapper.Map<Tenant>(tenantDto);

        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        var tenantToUpdate = await Repository.Tenant.GetTenantByIdAsync(tenant.Id, trackChanges: false);
        Assert.That(tenantToUpdate, Is.Not.Null); // Make sure tenant is there before we update

        // Act
        var tenantForUpdateDto = new TenantForUpdateDto { Name = "Updated Test Tenant" };
        var updatedTenant = await Mediator.Send(new UpdateTenantCommand(tenant.Id, tenantForUpdateDto, true));

        // Assert
        var tenantToUpdateCheck = await Repository.Tenant.GetTenantByIdAsync(tenant.Id, trackChanges: false);
        Assert.That(tenantToUpdateCheck!.Name, Is.EqualTo("Updated Test Tenant"));
    }

    [Test]
    public async Task DeleteTenantCommand_RemovesTenantFromDatabase()
    {
        // Arrange
        var tenantDto = new TenantDto { Name = "Test Tenant" };
        var tenant = Mapper.Map<Tenant>(tenantDto);

        Repository.Tenant.CreateTenant(tenant);
        await Repository.SaveAsync();

        var tenantToDelete = await Repository.Tenant.GetTenantByIdAsync(tenant.Id, trackChanges: false);
        Assert.That(tenantToDelete, Is.Not.Null); // Make sure tenant is there before we delete

        // Act
        await Mediator.Send(new DeleteTenantCommand(tenant.Id, true));

        // Assert
        var deletedTenant = await Repository.Tenant.GetTenantByIdAsync(tenant.Id, trackChanges: false);
        Assert.That(deletedTenant, Is.Null); // Tenant should be deleted, so we expect null
    }

}