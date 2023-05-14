using Domain.Models;
using Microsoft.AspNetCore.Http;
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
public class RolesController : ControllerBase
{

}
