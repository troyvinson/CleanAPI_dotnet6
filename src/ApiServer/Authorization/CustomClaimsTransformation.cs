using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ApiServer.Transformations;

public class CustomClaimsTransformation : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity claimsIdentity = new();

        //get roles from the db


        if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Role))
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
        }

        principal.AddIdentity(claimsIdentity);
        return Task.FromResult(principal);
    }
}
