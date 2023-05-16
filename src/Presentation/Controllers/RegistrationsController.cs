using Application.Commands.Users;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers;

/// <summary>
/// Members exist only in the context of a tenant.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
//[SwaggerResponse(StatusCodes.Status401Unauthorized)]
//[SwaggerResponse(StatusCodes.Status403Forbidden)]
[SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
public class RegistrationsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public RegistrationsController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration is null)
            return BadRequest("UserForRegistrationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var result = await _sender.Send(new RegisterUserCommand(userForRegistration));

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return Created("helpme", result);
    }
}
