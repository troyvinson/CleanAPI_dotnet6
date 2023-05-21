using Application.Features.Members.Commands;
using Application.Features.Members.Queries;
using Domain.Models;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace Presentation.Controllers;

/// <summary>
/// Members exist only in the context of a tenant.
/// </summary>
[Route("api/[controller]/{tenantId:Guid}/members")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
//[SwaggerResponse(StatusCodes.Status401Unauthorized)]
//[SwaggerResponse(StatusCodes.Status403Forbidden)]
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
    /// Get a member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberId"></param>
    /// <returns></returns>
    [HttpGet("{memberId:Guid}", Name = "GetMemberForTenant")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MemberDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<IActionResult> GetMemberForTenantAsync(Guid tenantId, Guid memberId)
    {
        var member = await _sender.Send(new GetMemberForTenantQuery(tenantId, memberId, TrackChanges: false));

        return Ok(member);
    }

    /// <summary>
    /// Get a list of members for a tenant  
    /// </summary>
    /// <remarks><![CDATA[
    /// <h2>Searching and Sorting</h2>
    /// <h3>SearchTerm</h3>
    /// Searches for term in User.Username, User.GivenName, and User.Surname
    /// <ul>Example:
    /// <li>?searchTerm=john</li>
    /// </ul>
    /// <h3>OrderBy</h3>
    /// Sort by any field. My use asc or desc (default = asc).<br/>
    /// Additional sort fields are separated by commas.
    /// <ul>Example:
    /// <li>?orderBy=User.Username desc</li>
    /// <li>?orderBy=Position,User.Username desc</li>
    /// </ul>
    /// ]]></remarks>
    /// <param name="tenantId"></param>
    /// <param name="memberParameters"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMembersForTenantAsync(Guid tenantId, [FromQuery] MemberParameters memberParameters)
    {
        var members = await _sender.Send(new GetMembersForTenantQuery(tenantId, memberParameters, TrackChanges: false));

        return Ok(members);
    }

    /// <summary>
    /// Get a list members for a tenant using pagination
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberParameters"></param>
    /// <remarks><![CDATA[
    /// <h2>Searching and Sorting</h2>
    /// <h3>SearchTerm</h3>
    /// Searches for term in User.Username, User.GivenName, and User.Surname
    /// <ul>Example:
    /// <li>?searchTerm=john</li>
    /// </ul>
    /// <h3>OrderBy</h3>
    /// Sort by any field. My use asc or desc (default = asc).<br/>
    /// Additional sort fields are separated by commas.
    /// <ul>Example:
    /// <li>?orderBy=User.Username desc</li>
    /// <li>?orderBy=Position,User.Username desc</li>
    /// </ul>
    /// <h2>Pagination</h2>
    /// <h3>PageSize and PageNumber</h3>
    /// PageSize is number of records to return per page (deafult = 10, max = 50).<br/> 
    /// PageNumber is the page to return (default = 1)<br/>
    /// <ul>Example:
    /// <li>?pageSize=25&pageNumber=1</li>
    /// </ul>
    /// <h3>Pagination Metadata</h3>
    /// Response header contains a custom header, X-Pagination, which contains pagination metadata
    /// <ul>Example
    /// <li>x-pagination: {"CurrentPage":1,"TotalPages":3,"PageSize":10,"TotalCount":2,"HasPrevious":false,"HasNext":true}</li>
    /// </ul>
    /// ]]></remarks>
    /// <returns></returns>
    [HttpGet("paged")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMembersForTenantPagedAsync(Guid tenantId, [FromQuery] MemberAndPagingParameters memberParameters)
    {
        (IEnumerable<MemberDto> members, PagingMetaData metaData) = await _sender.Send(new GetMembersForTenantPagedQuery(tenantId, memberParameters, TrackChanges: false));

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

        return Ok(members);
    }

    /// <summary>
    /// Gets a list of members by their ids
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberIds"></param>
    /// <param name="memberParameters"></param>
    /// <remarks><![CDATA[
    /// <p>Replace {ids} with a comma-delimited series of ints.</p>
    /// <h2>Searching and Sorting</h2>
    /// <h3>SearchTerm</h3>
    /// Searches for term in User.Username, User.GivenName, and User.Surname
    /// <ul>Example:
    /// <li>?searchTerm=john</li>
    /// </ul>
    /// <h3>OrderBy</h3>
    /// Sort by any field. My use asc or desc (default = asc).<br/>
    /// Additional sort fields are separated by commas.
    /// <ul>Example:
    /// <li>?orderBy=User.Username desc</li>
    /// <li>?orderBy=Position,User.Username desc</li>
    /// </ul>
    /// ]]></remarks>
    /// <returns></returns>
    [HttpGet("collection/{memberIds}", Name = "MemberCollection")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
    public async Task<IActionResult> GetMemberCollectionAsync(Guid tenantId, string memberIds, [FromQuery] MemberParameters memberParameters)
    {
        var members = await _sender.Send(new GetMembersByIdsQuery(tenantId, memberIds, memberParameters, TrackChanges: false));

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
    public async Task<IActionResult> CreateMemberForTenant(Guid tenantId, [FromBody] MemberForCreationDto memberToCreate)
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
    /// <param name="memberId"></param>
    /// <param name="memberToUpdate"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPut("{memberId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMemberForTenant(Guid tenantId, Guid memberId, [FromBody] MemberForUpdateDto memberToUpdate)
    {
        if (memberToUpdate is null)
            return BadRequest("MemberForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateMemberCommand(tenantId, memberId, memberToUpdate, TenantTrackChanges: false, MemberTrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an member for a tenant 
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberId"></param>
    /// <param name="patchDoc"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPatch("{memberId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PartiallyUpdateMemberForTenantAsync(Guid tenantId, Guid memberId,
        [FromBody] JsonPatchDocument<MemberForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        (MemberForUpdateDto memberToPatch, _) = await _sender.Send(new GetMemberForPatchQuery(tenantId, memberId, TenantTrackChanges: false, MemberTrackChanges: true));

        patchDoc.ApplyTo(memberToPatch, ModelState);

        TryValidateModel(memberToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateMemberCommand(tenantId, memberId, memberToPatch, TenantTrackChanges: false, MemberTrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Deletes an member for a tenant
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="memberId"></param>
    [HttpDelete("{memberId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMemberForTenant(Guid tenantId, Guid memberId)
    {
        await _publisher.Publish(new DeleteMemberCommand(tenantId, memberId, TrackChanges: false));

        return NoContent();
    }

}
