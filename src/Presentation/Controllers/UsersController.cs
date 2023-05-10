using Application.Commands.Users;
using Application.Notifications;
using Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/users")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
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
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var user = await _sender.Send(new GetUserQuery(id, TrackChanges: false));

        return Ok(user);
    }

    /// <summary>
    /// Gets a collection of users by their ids
    /// </summary>
    /// <remarks>Replace {userIds} with a comma-delimited series of ints. 
    /// Swagger does not do this very well, so try testing in Postman.</remarks>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpGet("collection/{ids}", Name = "UserCollection")]
    public async Task<IActionResult> GetUserCollectionAsync(string ids)
    {
        var users = await _sender.Send(new GetUsersByIdsQuery(ids, TrackChanges: false));

        return Ok(users);
    }


    /// <summary>
    /// Creates a newly created user
    /// </summary>
    /// <param name="userToCreate"></param>
    /// <returns>A newly created user</returns>
    [HttpPost(Name = "CreateUser")]
    //#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
    public async Task<IActionResult> CreateUserAsync([FromBody] UserForCreationDto userToCreate)
    {
        var user = await _sender.Send(new CreateUserCommand(userToCreate));

        return CreatedAtRoute("UserById", new { userId = user.Id }, user);
    }

    /// <summary>
    /// Creates new users from a collection
    /// </summary>
    /// <param name="userCollection"></param>
    /// <returns></returns>
    [HttpPost("collection")]
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
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUserAsync(int id, UserForUpdateDto userForUpdateDto)
    {
        if (userForUpdateDto is null)
            return BadRequest("UserForUpdateDto object is null");

        await _sender.Send(new UpdateUserCommand(id, userForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUserAsync(int userId)
    {
        await _publisher.Publish(new UserDeletedNotification(userId, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an existing user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
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
