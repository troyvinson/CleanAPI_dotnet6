using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[SwaggerResponse(StatusCodes.Status401Unauthorized)]
[SwaggerResponse(StatusCodes.Status403Forbidden)]
[SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
public class SessionsController : ControllerBase
{
    /// <summary>
    /// TODO: Creates a new session for a user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateSession(LoginRequest request)
    {
        // Handle user authentication and return access and refresh tokens
        await Task.CompletedTask;

        //return Ok(tokens);
        return Ok();
    }

    /// <summary>
    /// TODO: Refreshes a session for a user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> RefreshSession(RefreshTokenRequest request)
    {
        // Handle refresh token request and return a new access token
        await Task.CompletedTask;

        //return Ok(tokens);
        return Ok();
    }

    /// <summary>
    /// TODO: Revokes a session for a user
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RevokeSession()
    {
        // Handle refresh token request and return a new access token
        await Task.CompletedTask;

        //return Ok(tokens);
        return Ok();
    }

    /// <summary>
    /// Get available HTTP Verbs
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "OPTIONS, POST, PUT, DELETE");
        return Ok();
    }

}
