using Application.Commands.Tenants;
using Application.Notifications;
using Application.Queries.Tenants;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/tenants")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
public class TenantsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public TenantsController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// Gets the list of all tenants
    /// </summary>
    /// <returns>The tenants list</returns>
    [HttpGet(Name = "GetTenants")]
    public async Task<IActionResult> GetTenantsAsync()
    {
        var tenants = await _sender.Send(new GetTenantsQuery(TrackChanges: false));

        return Ok(tenants);
    }

    /// <summary>
    /// Get a tenant by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "TenantById")]
    public async Task<IActionResult> GetTenantAsync(int id)
    {
        var tenant = await _sender.Send(new GetTenantQuery(id, TrackChanges: false));

        return Ok(tenant);
    }

    /// <summary>
    /// Gets a collection of tenants by their ids
    /// </summary>
    /// <remarks>Replace {tenantIds} with a comma-delimited series of ints. 
    /// Swagger does not do this very well, so try testing in Postman.</remarks>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpGet("collection/{ids}", Name = "TenantCollection")]
    public async Task<IActionResult> GetTenantCollectionAsync(string ids)
    {
        var tenants = await _sender.Send(new GetTenantsByIdsQuery(ids, TrackChanges: false));

        return Ok(tenants);
    }


    /// <summary>
    /// Creates a newly created tenant
    /// </summary>
    /// <param name="tenantToCreate"></param>
    /// <returns>A newly created tenant</returns>
    [HttpPost(Name = "CreateTenant")]
    public async Task<IActionResult> CreateTenantAsync([FromBody] TenantForCreationDto tenantToCreate)
    {
        var tenant = await _sender.Send(new CreateTenantCommand(tenantToCreate));

        return CreatedAtRoute("TenantById", new { tenantId = tenant.Id }, tenant);
    }

    /// <summary>
    /// Creates new tenants from a collection
    /// </summary>
    /// <param name="tenantCollection"></param>
    /// <returns></returns>
    [HttpPost("collection")]
    public async Task<IActionResult> CreateTenantCollectionAsync
        ([FromBody] IEnumerable<TenantForCreationDto> tenantCollection)
    {
        (IEnumerable<TenantDto> tenants, string ids) = await _sender.Send(new CreateTenantCollectionCommand(tenantCollection));

        return CreatedAtRoute("TenantCollection", new { ids }, tenants);
    }

    /// <summary>
    /// Updates an existing tenant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tenantForUpdateDto"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTenantAsync(int id, TenantForUpdateDto tenantForUpdateDto)
    {
        if (tenantForUpdateDto is null)
            return BadRequest("TenantForUpdateDto object is null");

        await _sender.Send(new UpdateTenantCommand(id, tenantForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTenantAsync(int tenantId)
    {
        await _publisher.Publish(new TenantDeletedNotification(tenantId, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an existing tenant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateTenantAsync(int id, [FromBody] JsonPatchDocument<TenantForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        (TenantForUpdateDto tenantToPatch, _) = await _sender.Send(new GetTenantForPatchQuery(id, TrackChanges: false));

        patchDoc.ApplyTo(tenantToPatch, ModelState);

        TryValidateModel(tenantToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateTenantCommand(id, tenantToPatch, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Get available HTTP Verbs
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, PATCH, DELETE");
        return Ok();
    }

}
