using Application.Features.Tenants.Commands;
using Application.Features.Tenants.Queries;
using Application.Notifications;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers;

[Route("api/tenants")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
//[SwaggerResponse(StatusCodes.Status401Unauthorized)]
//[SwaggerResponse(StatusCodes.Status403Forbidden)]
[SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
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
    /// Get a tenant by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:Guid}", Name = "TenantById")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TenantDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<IActionResult> GetTenantAsync(Guid id)
    {
        var tenant = await _sender.Send(new GetTenantQuery(id, TrackChanges: false));

        return Ok(tenant);
    }

    /// <summary>
    /// Gets the list of all tenants
    /// </summary>
    /// <returns>The tenants list</returns>
    [HttpGet(Name = "GetTenants")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TenantDto>))]
    public async Task<IActionResult> GetTenantsAsync()
    {
        var tenants = await _sender.Send(new GetTenantsQuery(TrackChanges: false));

        return Ok(tenants);
    }

    /// <summary>
    /// Gets a list of tenants by their ids
    /// </summary>
    /// <remarks>Replace {tenantIds} with a comma-delimited series of ints. </remarks>
    /// <param name="ids"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TenantDto>))]
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
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPost(Name = "CreateTenant")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    public async Task<IActionResult> CreateTenantAsync([FromBody] TenantForCreationDto tenantToCreate)
    {
        var tenant = await _sender.Send(new CreateTenantCommand(tenantToCreate));

        return CreatedAtRoute("TenantById", new { tenantId = tenant.Id }, tenant);
    }

    /// <summary>
    /// Creates new tenants from a collection
    /// </summary>
    /// <param name="tenantCollection"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPost("collection")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
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
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTenantAsync(Guid id, TenantForUpdateDto tenantForUpdateDto)
    {
        if (tenantForUpdateDto is null)
            return BadRequest("TenantForUpdateDto object is null");

        await _sender.Send(new UpdateTenantCommand(id, tenantForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an existing tenant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPatch("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PartiallyUpdateTenantAsync(Guid id, [FromBody] JsonPatchDocument<TenantForUpdateDto> patchDoc)
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
    /// Deletes an existing tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTenantAsync(Guid tenantId)
    {
        await _publisher.Publish(new TenantDeletedNotification(tenantId, TrackChanges: false));

        return NoContent();
    }

}
