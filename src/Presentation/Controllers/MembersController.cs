using Application.Commands.Members;
using Application.Queries.Members;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.Controllers;

[Authorize]
[Route("api/tenants/{tenantId:int}/members")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
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
    /// Get all members for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberParameters"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetMembersForTenantAsync(int tenantId, [FromQuery] MemberParameters memberParameters)
    {
        (IEnumerable<MemberDto> members, MetaData metaData) = await _sender.Send(new GetMembersForTenantQuery(tenantId, memberParameters, TrackChanges: false));

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(members);
    }

    /// <summary>
    /// Get an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetMemberForTenant")]
    public async Task<IActionResult> GetMemberForTenantAsync(int tenantId, int id)
    {
        var member = await _sender.Send(new GetMemberForTenantQuery(tenantId, id, TrackChanges: false));

        return Ok(member);
    }

    /// <summary>
    /// Creates a newly created member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberToCreate"></param>
    /// <returns>A newly created tenant</returns>
    [HttpPost]
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
    /// Deletes an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMemberForTenant(int tenantId, int id)
    {
        await _publisher.Publish(new DeleteMemberCommand(tenantId, id, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Updates an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="id"></param>
    /// <param name="memberToUpdate"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
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
    /// <returns></returns>
    [HttpPatch("{id:int}")]
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
