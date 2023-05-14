using Application.Commands.Users;
using Application.Notifications;
using Application.Queries.Users;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
//[SwaggerResponse(StatusCodes.Status401Unauthorized)]
//[SwaggerResponse(StatusCodes.Status403Forbidden)]
[SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public UsersController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// Gets the list of all users
    /// </summary>
    /// <returns>The users list</returns>
    [HttpGet(Name = "GetUsers")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _sender.Send(new GetUsersQuery(TrackChanges: false));

        return Ok(users);
    }

    /// <summary>
    /// Get a user by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "UserById")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var user = await _sender.Send(new GetUserQuery(id, TrackChanges: false));

        return Ok(user);
    }

    /// <summary>
    /// Gets a list of users by their ids
    /// </summary>
    /// <remarks>Replace {userIds} with a comma-delimited series of ints.</remarks> 
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpGet("collection/{ids}", Name = "UserCollection")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserCollectionAsync(string ids)
    {
        var users = await _sender.Send(new GetUsersByIdsQuery(ids, TrackChanges: false));

        return Ok(users);
    }


    /// <summary>
    /// Creates a newly created user
    /// </summary>
    /// <param name="userToCreate"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserForCreationDto userToCreate)
    {
        var user = await _sender.Send(new CreateUserCommand(userToCreate));

        return CreatedAtRoute("UserById", new { userId = user.Id }, user);
    }

    /// <summary>
    /// Creates new users from a collection
    /// </summary>
    /// <param name="userCollection"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPost("collection")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    public async Task<IActionResult> CreateUserCollectionAsync
        ([FromBody] IEnumerable<UserForCreationDto> userCollection)
    {
        (IEnumerable<UserDto> users, string ids) = await _sender.Send(new CreateUserCollectionCommand(userCollection));

        return CreatedAtRoute("UserCollection", new { ids }, users);
    }

    /// <summary>
    /// Updates an existing user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userForUpdateDto"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUserAsync(int id, UserForUpdateDto userForUpdateDto)
    {
        if (userForUpdateDto is null)
            return BadRequest("UserForUpdateDto object is null");

        await _sender.Send(new UpdateUserCommand(id, userForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an existing user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <response code="422">Unprocessable Entity: returns dictionary of errors</response>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(IReadOnlyDictionary<string, string[]>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PartiallyUpdateUserAsync(int id,
        [FromBody] JsonPatchDocument<UserForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        (UserForUpdateDto userToPatch, _) =
            await _sender.Send(new GetUserForPatchQuery(id, TrackChanges: false));

        patchDoc.ApplyTo(userToPatch, ModelState);

        _ = TryValidateModel(userToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateUserCommand(id, userToPatch, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUserAsync(int userId)
    {
        await _publisher.Publish(new UserDeletedNotification(userId, TrackChanges: false));

        return NoContent();
    }


}
