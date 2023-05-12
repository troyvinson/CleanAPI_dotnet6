using Application.Commands.Members;
using Application.Queries.Members;
using Domain.Models;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace Presentation.Controllers;

[Route("api/[controller]/{tenantId:int}/members")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[SwaggerResponse(StatusCodes.Status401Unauthorized)]
[SwaggerResponse(StatusCodes.Status403Forbidden)]
[SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
public class MembersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public MembersController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// Get an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetMemberForTenant")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MemberDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<IActionResult> GetMemberForTenantAsync(int tenantId, int id)
    {
        var member = await _sender.Send(new GetMemberForTenantQuery(tenantId, id, TrackChanges: false));

        return Ok(member);
    }

    /// <summary>
    /// Get a list of members for a tenant  
    /// </summary>
    /// <remarks>Replace {tenantIds} with a comma-delimited series of ints. </remarks>
    /// <param name="tenantId"></param>
    /// <param name="memberParameters"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMembersForTenantAsync(int tenantId, [FromQuery] MemberParameters memberParameters)
    {
        var members = await _sender.Send(new GetMembersForTenantQuery(tenantId, memberParameters, TrackChanges: false));

        return Ok(members);
    }

    /// <summary>
    /// Get a list members for a tenant using pagination
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberParameters"></param>
    /// <returns></returns>
    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMembersForTenantPagedAsync(int tenantId, [FromQuery] MemberAndPagingParameters memberParameters)
    {
        (IEnumerable<MemberDto> members, PagingMetaData metaData) = await _sender.Send(new GetMembersForTenantPagedQuery(tenantId, memberParameters, TrackChanges: false));

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(members);
    }

    /// <summary>
    /// Gets a list of members by their ids
    /// </summary>
    /// <remarks>Replace {tenantIds} with a comma-delimited series of ints. </remarks>
    /// <param name="tenantId"></param>
    /// <param name="ids"></param>
    /// <param name="memberParameters"></param>
    /// <returns></returns>
    [HttpGet("collection/{ids}", Name = "MemberCollection")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMemberCollectionAsync(int tenantId, string ids, [FromQuery] MemberParameters memberParameters)
    {
        var members = await _sender.Send(new GetMembersByIdsQuery(tenantId, ids, memberParameters, TrackChanges: false));

        return Ok(members);
    }

    /// <summary>
    /// Creates a newly created member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberToCreate"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    public async Task<IActionResult> CreateMemberForTenant(int tenantId, [FromBody] MemberForCreationDto memberToCreate)
    {
        if (memberToCreate is null)
            return BadRequest("MemberForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var memberToReturn = await _sender.Send(new CreateMemberCommand(tenantId, memberToCreate));

        return CreatedAtRoute("GetMemberForTenant", new { tenantId, memberToReturn.Id }, memberToReturn);
    }

    /// <summary>
    /// Updates an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <param name="memberToUpdate"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMemberForTenant(int tenantId, int id, [FromBody] MemberForUpdateDto memberToUpdate)
    {
        if (memberToUpdate is null)
            return BadRequest("MemberForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateMemberCommand(tenantId, id, memberToUpdate, TenantTrackChanges: false, MemberTrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an member for a tenant 
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PartiallyUpdateMemberForTenantAsync(int tenantId, int id,
        [FromBody] JsonPatchDocument<MemberForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        (MemberForUpdateDto memberToPatch, _) = await _sender.Send(new GetMemberForPatchQuery(tenantId, id, TenantTrackChanges: false, MemberTrackChanges: true));

        patchDoc.ApplyTo(memberToPatch, ModelState);

        TryValidateModel(memberToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateMemberCommand(tenantId, id, memberToPatch, TenantTrackChanges: false, MemberTrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Deletes an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMemberForTenant(int tenantId, int id)
    {
        await _publisher.Publish(new DeleteMemberCommand(tenantId, id, TrackChanges: false));

        return NoContent();
    }

}
